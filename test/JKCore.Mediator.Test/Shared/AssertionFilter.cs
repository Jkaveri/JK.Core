#region

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Castle.Components.DictionaryAdapter;
using JKCore.Mediator.Abstracts;
using Xunit;

#endregion

namespace JKCore.Mediator.Test.Shared
{
    public class AssertionFilter : MediatorFilter
    {
        public static List<object> Messages { get; } = new List<object>();

        public override Task<IMediatorResult<TResult>> Apply<TMessage, TResult>(TMessage message,
            Func<TMessage, CancellationToken, Task<IMediatorResult<TResult>>> next,
            CancellationToken cancellationToken = new CancellationToken())
        {
            Assert.NotNull(message);

            Messages.Add(message);

            return next(message, cancellationToken);
        }
    }
}