// Copyright (c) Ho Nguyen. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

#region

using System.Threading;
using System.Threading.Tasks;
using JKCore.Mediator.Events;

#endregion

namespace JKCore.Mediator
{
    #region

    #endregion

    /// <summary>
    /// </summary>
    public interface IMediator
    {
        /// <summary>
        ///     Publish envent async.
        /// </summary>
        Task PublishAsync<TMessage>(TMessage message, CancellationToken cancellationToken = default(CancellationToken))
            where TMessage : IAsyncEvent;

        /// <summary>
        ///     Sends command asynchronous.
        /// </summary>
        Task<IMediatorResult<TResult>> SendAsync<TResult>(IMessage<TResult> command,
            CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        ///     Sends command asynchronous.
        /// </summary>
        Task<IMediatorResult> SendAsync(IMessage command,
            CancellationToken cancellationToken = default(CancellationToken));
    }
}