#region

using System.Threading;
using System.Threading.Tasks;
using JKCore.Mediator.Abstracts;

#endregion

namespace JKCore.Mediator
{
    public delegate Task<IMediatorResult<TResult>> MediatorPipeLineDelegate<TResult>(IMessage<TResult> message,
        CancellationToken token);
}