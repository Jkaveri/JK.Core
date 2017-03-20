// Copyright (c) Ho Nguyen. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace JKCore.Mediator
{
    #region

    using System.Threading.Tasks;

    using JKCore.Mediator.Commands;
    using JKCore.Mediator.Events;
    using JKCore.Mediator.Queries;

    #endregion

    /// <summary>
    /// </summary>
    public interface IMediator
    {
        /// <summary>
        /// </summary>
        /// <typeparam name="TMessage"></typeparam>
        /// <param name="message"></param>
        void Publish<TMessage>(TMessage message) where TMessage : IEvent;

        /// <summary>
        /// </summary>
        /// <typeparam name="TMessage"></typeparam>
        /// <param name="message"></param>
        /// <returns></returns>
        Task PublishAsync<TMessage>(TMessage message) where TMessage : IAsyncEvent;

        /// <summary>
        /// Sends the command.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="command">The command.</param>
        /// <returns></returns>
        ICommandResult<TResult> Send<TResult>(ICommand<TResult> command);

        /// <summary>
        /// Sends the command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns></returns>
        ICommandResult Send(ICommand command);

        /// <summary>
        /// Sends command asynchronous.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="command">The command.</param>
        /// <returns><typeparamref name="TResult"/></returns>
        Task<ICommandResult<TResult>> SendAsync<TResult>(IAsyncCommand<TResult> command);

        /// <summary>
        /// Sends command asynchronous.
        /// </summary>
        /// <param name="command">A command</param>
        /// <returns><see cref="ICommandResult"/></returns>
        Task<ICommandResult> SendAsync(IAsyncCommand command);

        /// <summary>
        /// Execute <see cref="IQuery{TResult}"/>
        /// </summary>
        Task<TResult> Execute<TResult>(IQuery<TResult> query);
    }
}