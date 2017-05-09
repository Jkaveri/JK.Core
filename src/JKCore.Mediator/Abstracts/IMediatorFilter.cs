#region

using System;
using System.Threading;
using System.Threading.Tasks;

#endregion

namespace JKCore.Mediator.Abstracts
{
    public abstract class MediatorFilter
    {
        public abstract Task<IMediatorResult<TResult>> Apply<TMessage, TResult>(
            TMessage message,
            Func<TMessage, CancellationToken, Task<IMediatorResult<TResult>>> next,
            CancellationToken cancellationToken = default(CancellationToken)) where TMessage : IMessage<TResult>;
    }
}