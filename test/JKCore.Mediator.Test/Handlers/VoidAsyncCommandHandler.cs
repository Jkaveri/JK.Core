#region

using System.Threading;
using System.Threading.Tasks;
using JKCore.Mediator.Test.Messages;

#endregion

namespace JKCore.Mediator.Test.Handlers
{
    public class VoidAsyncCommandHandler : MediatorHandler<FakeMessage>
    {
        public override Task<IMediatorResult> Process(FakeMessage fakeMessage,
            CancellationToken cancellationToken = new CancellationToken())
        {
            fakeMessage.Action?.Invoke();
            return Task.FromResult(Success());
        }
    }
}