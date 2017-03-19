namespace JKCore.Mediator.Test.CommandHandlers
{
    using JKCore.Mediator.Commands;
    using JKCore.Mediator.Test.Commands;


    public class VoidCommandHandler : CommandHandler<VoidCommand>
    {
        public override ICommandResult Handle(VoidCommand command)
        {
            command.Action?.Invoke();
            return Success();
        }
    }
}
