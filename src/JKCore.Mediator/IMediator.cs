// Copyright (c) Ho Nguyen. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace JKCore.Mediator
{
    #region

    using System.Threading.Tasks;

    using JKCore.Mediator.Commands;
    using JKCore.Mediator.Events;
    using JKCore.Mediator.Queries;
    using System.Threading;

    #endregion

    /// <summary>
    /// </summary>
    public interface IMediator
    {
        /// <summary>
        /// Publish envent async.
        /// </summary>
        Task PublishAsync<TMessage>(TMessage message, CancellationToken cancellationToken = default(CancellationToken)) where TMessage : IAsyncEvent;
        
        /// <summary>
        /// Sends command asynchronous.
        /// </summary>
        Task<ICommandResult<TResult>> SendAsync<TResult>(IAsyncCommand<TResult> command, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Sends command asynchronous.
        /// </summary>
        Task<ICommandResult> SendAsync(IAsyncCommand command, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Execute <see cref="IQuery{TResult}"/>
        /// </summary>
        Task<TResult> Execute<TResult>(IQuery<TResult> query, CancellationToken cancellationToken = default(CancellationToken));
    }
}