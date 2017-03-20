// Copyright (c) Ho Nguyen. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace JKCore.Mediator
{
    #region

    using JKCore.Mediator.Commands;
    using JKCore.Mediator.Events;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Threading.Tasks;
    using JKCore.Mediator.Queries;

    #endregion

    /// <summary>
    /// </summary>
    public class Mediator : IMediator
    {
        private readonly ICommandHandlerProvider _handlerProvider;
        private readonly IEventListenersProvider _listenersProvider;
        private readonly IQueryProcessorProvider _processorProvider;

        /// <summary>
        ///     Initializes a new instance of the <see cref="Mediator" /> class.
        /// </summary>
        /// <param name="handlerProvider">
        ///     The handler resolver.
        /// </param>
        /// <param name="listenersProvider">
        ///     The listener resolver.
        /// </param>
        /// <param name="processorProvider">
        ///     Query processor provider.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// </exception>
        public Mediator(ICommandHandlerProvider handlerProvider, IEventListenersProvider listenersProvider, IQueryProcessorProvider processorProvider)
        {
            _handlerProvider = handlerProvider ?? throw new ArgumentNullException(nameof(handlerProvider));
            _listenersProvider = listenersProvider ?? throw new ArgumentNullException(nameof(listenersProvider));
            _processorProvider = processorProvider ?? throw new ArgumentNullException(nameof(processorProvider));
        }

        /// <summary>
        /// Execute <see cref="IQuery{TResult}"/>
        /// </summary>
        public Task<TResult> Execute<TResult>(IQuery<TResult> query)
        {
            var queryType = query.GetType();
            var method = this._processorProvider.GetType()
                .GetMethod("GetQueryProcessor")
                .MakeGenericMethod(queryType, typeof(TResult));

            var handler = method.Invoke(this._processorProvider, null);

            if (handler != null)
            {
                method = handler.GetType().GetMethod("Execute");
                return (Task<TResult>) method.Invoke(handler, new object[] { query });
            }

            throw new InvalidOperationException("Query processor not found.");
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
            var receivers = this._listenersProvider.ResolveListeners<TMessage>().ToList();

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
            var receivers = this._listenersProvider.ResolveAsyncListeners<TMessage>();
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
        public ICommandResult<TResult> Send<TResult>(ICommand<TResult> command)
        {
            var commandType = command.GetType();
            var method = this._handlerProvider.GetType()
                .GetMethods()
                .Where(t =>
                {
                    if (t.Name == "ResolveHandler")
                    {
                        var args = t.GetGenericArguments();
                        return args.Length == 2;
                    }
                    return false;
                })
                .First()
                .MakeGenericMethod(commandType, typeof(TResult));

            var handler = method.Invoke(_handlerProvider, null);

            if (handler != null)
            {
                method = handler.GetType().GetMethod("Handle");
                return (ICommandResult<TResult>)method.Invoke(handler, new object[] { command });
            }

            throw new InvalidOperationException("Handler not found");
        }

        /// <summary>
        /// Send a command.
        /// </summary>
        public ICommandResult Send(ICommand command)
        {
            var commandType = command.GetType();
            var method = this._handlerProvider.GetType()
                .GetMethods()
                .Where(t =>
                {
                    if (t.Name == "ResolveHandler")
                    {
                        var args = t.GetGenericArguments();
                        return args.Length == 1;
                    }
                    return false;
                })
                .First()
                .MakeGenericMethod(commandType);

            var handler = method.Invoke(this._handlerProvider, null);

            if (handler != null)
            {
                method = handler.GetType().GetMethod("Handle");
                return (ICommandResult)method.Invoke(handler, new object[] { command });
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
        public Task<ICommandResult<TResult>> SendAsync<TResult>(IAsyncCommand<TResult> command)
        {
            var commandType = command.GetType();
            var method = _handlerProvider.GetType()
                .GetMethods()
                .Where(t =>
                {
                    if (t.Name == "ResolveAsyncHandler")
                    {
                        var args = t.GetGenericArguments();
                        return args.Length == 2;
                    }
                    return false;
                })
                .First()
                .MakeGenericMethod(commandType, typeof(TResult));

            var handler = method.Invoke(this._handlerProvider, null);

            if (handler != null)
            {
                method = handler.GetType().GetMethod("Handle");
                return (Task<ICommandResult<TResult>>)method.Invoke(handler, new object[] { command });
            }

            throw new InvalidOperationException("Handler not found");
        }

        /// <summary>
        /// Send a command.
        /// </summary>
        /// <exception cref="InvalidOperationException"></exception>
        public Task<ICommandResult> SendAsync(IAsyncCommand command)
        {
            var commandType = command.GetType();
            var method = this._handlerProvider.GetType()
                .GetMethods()
                .Where(t =>
                {
                    if (t.Name == "ResolveAsyncHandler")
                    {
                        var args = t.GetGenericArguments();
                        return args.Length == 1;
                    }
                    return false;
                })
                .First()
                .MakeGenericMethod(commandType);

            var handler = method.Invoke(this._handlerProvider, null);

            if (handler != null)
            {
                method = handler.GetType().GetMethod("Handle");
                return (Task<ICommandResult>)method.Invoke(handler, new object[] { command });
            }

            throw new InvalidOperationException("Handler not found");
        }
    }
}