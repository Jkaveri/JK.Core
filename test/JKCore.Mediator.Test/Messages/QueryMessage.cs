using JKCore.Mediator.Abstracts;

namespace JKCore.Mediator.Test.Messages
{
    public class QueryMessage : IQuery<int>
    {
        public int ExpectedInt { get; set; }
    }
}