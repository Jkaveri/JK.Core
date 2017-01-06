namespace JKCore.Mediator.Test.CommandHandlers
{
    using System;
    using JKCore.Mediator.Commands;
    using JKCore.Mediator.Test.Commands;

    public class ExpectedResultCommandHandler : CommandHandler<ExpectedResultCommand, object>
    {
        /// <summary>
        /// </summary>
        /// <param name="command">
        ///     The command.
        /// </param>
        /// <returns>
        /// </returns>
        public override ICommandResult<object> Handle(ExpectedResultCommand command)
        {
            return this.Success(command.ExpectedResult);
        }
    }
}