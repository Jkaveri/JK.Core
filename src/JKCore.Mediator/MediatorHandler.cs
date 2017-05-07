#region

using System.Threading;
using System.Threading.Tasks;

#endregion

namespace JKCore.Mediator
{
    /// <summary>
    ///     Async command handler.
    /// </summary>
    public abstract class MediatorHandler<TMessage, TResult> : CommandResultFactory<TResult>,
        IMediatorHandler<TMessage, TResult>
        where TMessage : IMessage<TResult>
    {
        /// <summary>
        ///     Handle command asynchronously.
        /// </summary>
        public abstract Task<IMediatorResult<TResult>> Process(TMessage command,
            CancellationToken cancellationToken = default(CancellationToken));
    }

    /// <summary>
    ///     Mediator handler abstract class.
    /// </summary>
    public abstract class MediatorHandler<TCommand> : CommandResultFactory, IMediatorHandler<TCommand>
        where TCommand : IMessage
    {
        public abstract Task<IMediatorResult> Process(TCommand message,
            CancellationToken cancellationToken = new CancellationToken());
    }
}