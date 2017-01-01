namespace JKCore.Mediator.Test.CommandHandlers
{
    using JKCore.Mediator.Commands;
    using JKCore.Mediator.Test.Commands;

    public class ExpectedResultCommandHandler : ICommandHandler<ExpectedResultCommand, object>
    {
        /// <summary>
        /// </summary>
        /// <param name="command">
        /// The command.
        /// </param>
        /// <returns>
        /// </returns>
        public object Handle(ExpectedResultCommand command)
        {
            return command.ExpectedResult;
        }
    }
}