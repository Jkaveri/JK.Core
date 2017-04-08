namespace JKCore.Mediator.Commands
{
    using System.Threading;
    #region

    using System.Threading.Tasks;

    #endregion

    /// <summary>
    ///     Async command handler.
    /// </summary>
    /// <typeparam name="TCommand"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    public abstract class AsyncCommandHandler<TCommand, TResult> : CommandResultFactory<TResult>,
                                                                   IAsyncCommandHandler<TCommand, TResult>
        where TCommand : IAsyncCommand<TResult>
    {
        /// <summary>
        ///     Handle command asynchronously.
        /// </summary>
        /// <param name="command">
        ///     The command.
        /// </param>
        /// <returns>
        /// </returns>
        public abstract Task<ICommandResult<TResult>> HandleAsync(TCommand command, CancellationToken cancellationToken = default(CancellationToken));
    }

    /// <summary>
    ///     Async command handler.
    /// </summary>
    /// <typeparam name="TCommand"></typeparam>
    public abstract class AsyncCommandHandler<TCommand> : CommandResultFactory,
                                                                   IAsyncCommandHandler<TCommand>
        where TCommand : IAsyncCommand
    {
        /// <summary>
        ///     Handle command asynchronously.
        /// </summary>
        public abstract Task<ICommandResult> HandleAsync(TCommand command, CancellationToken cancellationToken = default(CancellationToken));
    }
}