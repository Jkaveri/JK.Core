#region

using System.Threading;
using System.Threading.Tasks;
using JKCore.Mediator.Abstracts;

#endregion

namespace JKCore.Mediator.Internal
{
    internal abstract class MediatorHandlerImpl<TResult>
    {
        public abstract Task<IMediatorResult<TResult>> Handle(IMessage<TResult> message,
            IHandlerResolver handlerResolver, FilterManager filterManager, CancellationToken cancellationToken);
    }

    internal class MediatorHandlerImpl<TMessage, TResult> : MediatorHandlerImpl<TResult>
        where TMessage : IMessage<TResult>
    {
        public override Task<IMediatorResult<TResult>> Handle(IMessage<TResult> message,
            IHandlerResolver handlerResolver, FilterManager filterManager,
            CancellationToken cancellationToken)
        {
            var handler = handlerResolver.ResolveHandler<TMessage, TResult>();
            return filterManager.ApplyFilters(handler, (TMessage) message, cancellationToken);
        }
    }
}