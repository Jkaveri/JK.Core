#region

using System.Threading;
using System.Threading.Tasks;
using JKCore.Mediator.Test.Messages;

#endregion

namespace JKCore.Mediator.Test.Handlers
{
    #region

    #endregion

    public class ExpectedResultAsyncCommandHandler : MediatorHandler<ExpectedResultMessage, object>
    {
        public override Task<IMediatorResult<object>> Process(ExpectedResultMessage command,
            CancellationToken cancellationToken = new CancellationToken())
        {
            return Task.FromResult(Success(command.ExpectedResult));
        }
    }
}