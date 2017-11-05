using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using JKCore.Mediator.Abstracts;
using JKCore.Mediator.Test.Messages;
using JKCore.Mediator.Test.Shared;

namespace JKCore.Mediator.Test.Handlers
{
    public class UsedScopedService : MediatorHandler<ScopedMessage, string>
    {
        private readonly ScopedService _s;

        public UsedScopedService(ScopedService s)
        {
            _s = s;
        }
        
        public override Task<IMediatorResult<string>> Process(ScopedMessage message, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.FromResult(Success(_s.Id.ToString()));
        }
    }
}
