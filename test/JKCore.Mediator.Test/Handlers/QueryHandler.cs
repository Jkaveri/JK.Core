#region

using System;
using System.Threading;
using System.Threading.Tasks;
using JKCore.Mediator.Abstracts;
using JKCore.Mediator.Test.Messages;

#endregion

namespace JKCore.Mediator.Test.Handlers
{
    public class QueryHandler : MediatorHandler<QueryMessage, int>
    {
        public override Task<IMediatorResult<int>> Process(QueryMessage message,
            CancellationToken cancellationToken = new CancellationToken())
        {
            return Task.FromResult(Success(message.ExpectedInt));
        }
    }
}