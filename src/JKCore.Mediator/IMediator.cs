// Copyright (c) Ho Nguyen. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace JK.Core.Mediator
{
    #region

    using System.Threading.Tasks;

    using JK.Core.Mediator.Commands;
    using JK.Core.Mediator.Events;

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
        /// </summary>
        /// <typeparam name="TCommand"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="command"></param>
        /// <returns></returns>
        TResult Send<TCommand, TResult>(TCommand command) where TCommand : ICommand<TResult>;

        /// <summary>
        /// </summary>
        /// <typeparam name="TCommand"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="command"></param>
        /// <returns></returns>
        Task<TResult> SendAsync<TCommand, TResult>(TCommand command) where TCommand : IAsyncCommand<TResult>;
    }
}