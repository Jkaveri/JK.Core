namespace JKCore.Mediator.Commands
{
    /// <summary>
    /// </summary>
    /// <typeparam name="TCommand">
    /// </typeparam>
    /// <typeparam name="TResult">
    /// </typeparam>
    public abstract class CommandHandler<TCommand, TResult> : CommandResultFactory<TResult>,
                                                              ICommandHandler<TCommand, TResult>
        where TCommand : ICommand<TResult>
    {
        /// <summary>
        /// </summary>
        /// <param name="command">
        ///     The command.
        /// </param>
        /// <returns>
        /// </returns>
        public abstract ICommandResult<TResult> Handle(TCommand command);
    }
}