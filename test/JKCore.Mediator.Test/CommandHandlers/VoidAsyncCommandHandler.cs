namespace JKCore.Mediator.Test.CommandHandlers
{
    using JKCore.Mediator.Commands;
    using JKCore.Mediator.Test.Commands;
    using System.Threading;
    using System.Threading.Tasks;

    public class VoidAsyncCommandHandler : AsyncCommandHandler<VoidAsyncCommand>
    {
        public override Task<ICommandResult> HandleAsync(VoidAsyncCommand command, CancellationToken cancellationToken = default(CancellationToken))
        {
            command.Action?.Invoke();
            return Task.FromResult(Success());
        }
    }
}