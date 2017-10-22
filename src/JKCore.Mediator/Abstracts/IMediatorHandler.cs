// Copyright (c) Ho Nguyen. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

#region

using System.Threading;
using System.Threading.Tasks;

#endregion

namespace JKCore.Mediator.Abstracts
{
    /// <summary>
    ///     Handle message and return result.
    /// </summary>
    public interface IMediatorHandler<in TMessage, TResult> : IMediatorHandler where TMessage : IMessage<TResult>
    {
        /// <summary>
        ///     Processor message and return result
        /// </summary>
        Task<IMediatorResult<TResult>> Process(TMessage message,
            CancellationToken cancellationToken = default(CancellationToken));
    }

    public interface IMediatorHandler
    {
    }
}