// Copyright (c) Ho Nguyen. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace JKCore.Mediator
{
    #region

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Threading.Tasks;

    using JKCore.Mediator.Commands;
    using JKCore.Mediator.Events;

    #endregion

    /// <summary>
    /// </summary>
    public class Mediator : IMediator
    {
        private readonly ICommandHandlerResolver _handlerResolver;

        private readonly IEventListenerResolver _listenerResolver;

        /// <summary>
        ///     Initializes a new instance of the <see cref="Mediator" /> class.
        /// </summary>
        /// <param name="handlerResolver">
        ///     The handler resolver.
        /// </param>
        /// <param name="listenerResolver">
        ///     The listener resolver.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// </exception>
        public Mediator(ICommandHandlerResolver handlerResolver, IEventListenerResolver listenerResolver)
        {
            if (handlerResolver == null)
            {
                throw new ArgumentNullException(nameof(handlerResolver));
            }

            if (listenerResolver == null)
            {
                throw new ArgumentNullException(nameof(listenerResolver));
            }

            this._handlerResolver = handlerResolver;
            this._listenerResolver = listenerResolver;
        }

        /// <summary>
        /// </summary>
        /// <typeparam name="TCommand">
        /// </typeparam>
        /// <typeparam name="TResult">
        /// </typeparam>
        /// <returns>
        /// </returns>
        public FluentAsyncCommandSender<TCommand, TResult> PrepareAsyncCommandSender<TCommand, TResult>()
            where TCommand : IAsyncCommand<TResult>
        {
            return new FluentAsyncCommandSender<TCommand, TResult>(this);
        }

        /// <summary>
        /// </summary>
        /// <typeparam name="TCommand">
        /// </typeparam>
        /// <typeparam name="TResult">
        /// </typeparam>
        /// <returns>
        /// </returns>
        public FluentCommandSender<TCommand, TResult> PrepareCommandSender<TCommand, TResult>()
            where TCommand : ICommand<TResult>
        {
            return new FluentCommandSender<TCommand, TResult>(this);
        }

        /// <summary>
        /// </summary>
        /// <param name="message">
        ///     The message.
        /// </param>
        /// <typeparam name="TMessage">
        /// </typeparam>
        public void Publish<TMessage>(TMessage message) where TMessage : IEvent
        {
            var receivers = this._listenerResolver.ResolveListeners<TMessage>().ToList();

            foreach (var receiver in receivers)
            {
                receiver.Handle(message);
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="message">
        ///     The message.
        /// </param>
        /// <typeparam name="TMessage">
        /// </typeparam>
        /// <returns>
        /// </returns>
        public Task PublishAsync<TMessage>(TMessage message) where TMessage : IAsyncEvent
        {
            var receivers = this._listenerResolver.ResolveAsyncListeners<TMessage>();
            var asyncEventListeners = receivers as IList<IAsyncEventListener<TMessage>> ?? receivers.ToList();
            if (asyncEventListeners.Any())
            {
                return Task.WhenAll(asyncEventListeners.Select(t => t.Handle(message)));
            }

            return Task.Delay(0);
        }

        /// <summary>
        /// </summary>
        /// <param name="command">
        ///     The command.
        /// </param>
        /// <typeparam name="TResult">
        /// </typeparam>
        /// <returns>
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// </exception>
        public TResult Send<TResult>(ICommand<TResult> command)
        {
            var commandType = command.GetType();
            var method = this._handlerResolver.GetType()
                .GetMethod("ResolveHandler")
                .MakeGenericMethod(commandType, typeof(TResult));

            var handler = method.Invoke(this._handlerResolver, null);

            if (handler != null)
            {
                method = handler.GetType().GetMethod("Handle");
                return (TResult)method.Invoke(handler, new object[] { command });
            }

            throw new InvalidOperationException("Handler not found");
        }

        /// <summary>
        /// </summary>
        /// <param name="command">
        ///     The command.
        /// </param>
        /// <typeparam name="TResult">
        /// </typeparam>
        /// <returns>
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// </exception>
        public Task<TResult> SendAsync<TResult>(IAsyncCommand<TResult> command)
        {
            var commandType = command.GetType();
            var method = this._handlerResolver.GetType()
                .GetMethod("ResolveAsyncHandler")
                .MakeGenericMethod(commandType, typeof(TResult));

            var handler = method.Invoke(this._handlerResolver, null);

            if (handler != null)
            {
                method = handler.GetType().GetMethod("Handle");
                return (Task<TResult>)method.Invoke(handler, new object[] { command });
            }

            throw new InvalidOperationException("Handler not found");
        }
    }
}