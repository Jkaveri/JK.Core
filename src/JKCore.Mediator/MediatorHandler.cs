#region

using System.Threading;
using System.Threading.Tasks;
using JKCore.Mediator.Abstracts;

#endregion

namespace JKCore.Mediator
{
    /// <summary>
    ///     Async command handler.
    /// </summary>
    public abstract class MediatorHandler<TMessage, TResult> : MediatorResultFactory<TResult>,
        IMediatorHandler<TMessage, TResult>
        where TMessage : IMessage<TResult>
    {
        /// <summary>
        ///     Handle command asynchronously.
        /// </summary>
        public abstract Task<IMediatorResult<TResult>> Process(TMessage message,
            CancellationToken cancellationToken = default(CancellationToken));
    }
}