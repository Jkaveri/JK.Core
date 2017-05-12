#region

using System.Threading;
using System.Threading.Tasks;
using JKCore.Mediator.Abstracts;
using JKCore.Mediator.Test.Messages;

#endregion

namespace JKCore.Mediator.Test.Handlers
{
    public class ExpectedHandler : MediatorHandler<ExpectedResultMessage, object>
    {
        public override Task<IMediatorResult<object>> Process(ExpectedResultMessage message,
            CancellationToken cancellationToken = new CancellationToken())
        {
            return Task.FromResult(Success(message.ExpectedResult));
        }
    }

    public class ExpectedHandler2 : MediatorHandler<IExpectedMessage, object>
    {
        public override Task<IMediatorResult<object>> Process(IExpectedMessage message,
            CancellationToken cancellationToken = new CancellationToken())
        {
            return Task.FromResult(Success(message.Expected));
        }
    }
}