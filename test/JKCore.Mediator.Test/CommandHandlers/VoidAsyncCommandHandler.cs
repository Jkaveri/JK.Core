namespace JKCore.Mediator.Test.CommandHandlers
{
    using JKCore.Mediator.Commands;
    using JKCore.Mediator.Test.Commands;
    using System.Threading.Tasks;

    public class VoidAsyncCommandHandler : AsyncCommandHandler<VoidAsyncCommand>
    {
        public override Task<ICommandResult> Handle(VoidAsyncCommand command)
        {
            command.Action?.Invoke();
            return Task.FromResult(Success());
        }
    }
}