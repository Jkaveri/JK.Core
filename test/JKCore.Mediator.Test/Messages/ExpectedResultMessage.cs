namespace JKCore.Mediator.Test.Messages
{
    public class ExpectedResultMessage : IMessage<object>
    {
        public object ExpectedResult { get; set; }
    }
}