namespace JKCore.Mediator.Test.CommandHandlers
{
    #region

    using System.Threading.Tasks;

    using JKCore.Mediator.Commands;
    using JKCore.Mediator.Test.Commands;

    #endregion

    public class ExpectedResultAsyncCommandHandler : AsyncCommandHandler<ExpectedResultAsyncCommand, object>
    {
        public override Task<ICommandResult<object>> Handle(ExpectedResultAsyncCommand command)
        {
            return Task.FromResult(this.Success(command.ExpectedResult));
        }
    }
}