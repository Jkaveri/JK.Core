#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using JKCore.Mediator.Abstracts;

#endregion

namespace JKCore.Mediator
{
    public class FilterManager
    {
        private readonly IServiceProvider _serviceProvider;

        public FilterManager(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public Task<IMediatorResult<TResult>> ApplyFilters<TMessage, TResult>(
            IMediatorHandler<TMessage, TResult> handler, TMessage message, CancellationToken cancellationToken = default(CancellationToken)) where TMessage : IMessage<TResult>
        {
            var type = typeof(IEnumerable<>).MakeGenericType(typeof(MediatorFilter));

             var filters = ((IEnumerable<MediatorFilter>) _serviceProvider.GetService(type)).Reverse();

            Func<TMessage, CancellationToken, Task<IMediatorResult<TResult>>> next = (msg, token) => handler.Process(message, token);

            foreach (MediatorFilter filter in filters)
            {
                var next1 = next;
                next = (msg, token) => filter.Apply(msg, next1, token);
            }

            return next(message, cancellationToken);
        }
    }
}