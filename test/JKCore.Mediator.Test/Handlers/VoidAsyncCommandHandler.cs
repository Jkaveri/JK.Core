#region

using System.Threading;
using System.Threading.Tasks;
using JKCore.Mediator.Abstracts;
using JKCore.Mediator.Test.Messages;

#endregion

namespace JKCore.Mediator.Test.Handlers
{
    public class VoidAsyncCommandHandler : MediatorHandler<FakeMessage, bool>
    {
        public override Task<IMediatorResult<bool>> Process(FakeMessage message,
            CancellationToken cancellationToken = new CancellationToken())
        {
            message.Action?.Invoke();
            return Task.FromResult(Success());
        }
    }
}