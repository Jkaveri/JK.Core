using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using JKCore.Mediator.Abstracts;
using JKCore.Mediator.Test.Messages;

namespace JKCore.Mediator.Test.Handlers
{
    public class QueryInterfaceHandler : MediatorHandler<IQueryInterfaceMessage, int>
    {
        public override Task<IMediatorResult<int>> Process(IQueryInterfaceMessage command, CancellationToken cancellationToken = new CancellationToken())
        {
            return Task.FromResult(Success(command.ExpectedInt));
        }
    }
}
