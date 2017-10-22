using JKCore.Mediator.Abstracts;

namespace JKCore.Mediator.Test.Messages
{
    public interface IQueryInterfaceMessage : IQuery<int>
    {
        int ExpectedInt { get; set; }
    }

    public class QueryInterfaceMessage : IQueryInterfaceMessage
    {
        public int ExpectedInt { get; set; }
    }
}