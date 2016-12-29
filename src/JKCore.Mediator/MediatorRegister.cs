// Copyright (c) Ho Nguyen. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace JK.Core.Mediator
{
    #region

    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using JK.Core.Mediator.Commands;
    using JK.Core.Mediator.Events;

    using JKCore.Exceptions;

    using Microsoft.Extensions.DependencyInjection;

    #endregion

    /// <summary>
    ///     The mediator register.
    /// </summary>
    public class MediatorRegister : ICommandHandlerResolver, IEventListenerResolver
    {
        /// <summary>
        ///     The anonymous handlers.
        /// </summary>
        private static readonly ConcurrentDictionary<Type, object> AnoHandlers =
            new ConcurrentDictionary<Type, object>();

        /// <summary>
        ///     The anonymous receivers.
        /// </summary>
        private static readonly ConcurrentDictionary<Type, List<object>> AnoReceivers =
            new ConcurrentDictionary<Type, List<object>>();

        /// <summary>
        ///     The _container.
        /// </summary>
        private readonly IServiceProvider _serviceProvider;

        /// <summary>
        ///     Initializes a new instance of the <see cref="MediatorRegister" /> class.
        /// </summary>
        /// <param name="serviceProvider">
        ///     The service Provider.
        /// </param>
        public MediatorRegister(IServiceProvider serviceProvider)
        {
            this._serviceProvider = serviceProvider;
        }

        /// <summary>
        ///     The register anonymous handler.
        /// </summary>
        /// <param name="handler">
        ///     The handler.
        /// </param>
        /// <typeparam name="TCommand">
        /// </typeparam>
        /// <typeparam name="TResult">
        /// </typeparam>
        public void RegisterAnoHandler<TCommand, TResult>(Func<TCommand, TResult> handler)
            where TCommand : ICommand<TResult>
        {
            var cmdType = typeof(TCommand);
            AnoHandlers.AddOrUpdate(cmdType, handler, (type, exist) => handler);
        }

        /// <summary>
        ///     The register anonymous receiver.
        /// </summary>
        /// <param name="receiver">
        ///     The receiver.
        /// </param>
        /// <typeparam name="TMessage">
        /// </typeparam>
        public void RegisterAnoReceiver<TMessage>(Action<TMessage> receiver) where TMessage : IEvent
        {
            var msgType = typeof(TMessage);
            var receivers = AnoReceivers.GetOrAdd(msgType, new List<object>());
            receivers.Add(receiver);
        }

        /// <summary>
        ///     The resolve async handler.
        /// </summary>
        /// <typeparam name="TCommand">
        /// </typeparam>
        /// <typeparam name="TResult">
        /// </typeparam>
        /// <returns>
        ///     The <see cref="IAsyncCommandHandler{TCommand, TREsult}" />.
        /// </returns>
        /// <exception cref="HandlerNotFound">
        /// </exception>
        public IAsyncCommandHandler<TCommand, TResult> ResolveAsyncHandler<TCommand, TResult>()
            where TCommand : IAsyncCommand<TResult>
        {
            var cmdType = typeof(TCommand);
            object handlerWrapper;
            if (AnoHandlers.TryGetValue(cmdType, out handlerWrapper))
            {
                var handlerFn = handlerWrapper as Func<TCommand, Task<TResult>>;
                if (handlerFn != null)
                {
                    return new AnonymousAsyncCommandHandler<TCommand, TResult>(handlerFn);
                }
            }

            var handler = this._serviceProvider.GetService<IAsyncCommandHandler<TCommand, TResult>>();
            if (handler == null)
            {
                throw new HandlerNotFound(typeof(TCommand));
            }

            return handler;
        }

        /// <summary>
        ///     The resolve async listeners.
        /// </summary>
        /// <typeparam name="TMessage">
        /// </typeparam>
        /// <returns>
        ///     The <see cref="IEnumerable{T}" />.
        /// </returns>
        public IEnumerable<IAsyncEventListener<TMessage>> ResolveAsyncListeners<TMessage>() where TMessage : IAsyncEvent
        {
            var msgType = typeof(TMessage);
            List<IAsyncEventListener<TMessage>> receivers;

            try
            {
                receivers = this._serviceProvider.GetServices<IAsyncEventListener<TMessage>>().ToList();
            }
            catch (Exception)
            {
                receivers = new List<IAsyncEventListener<TMessage>>();
            }

            List<object> actionWrappers;
            if (AnoReceivers.TryGetValue(msgType, out actionWrappers))
            {
                var anoReceivers =
                    actionWrappers.Where(t => t.GetType() == typeof(Action<TMessage>))
                        .Select(t => new AnonymousAsyncEventListener<TMessage>((Func<TMessage, Task>)t));

                receivers.AddRange(anoReceivers);
            }

            return receivers;
        }

        /// <summary>
        ///     The resolve handler.
        /// </summary>
        /// <typeparam name="TCommand">
        /// </typeparam>
        /// <typeparam name="TResult">
        /// </typeparam>
        /// <returns>
        ///     The <see cref="ICommandHandler" />.
        /// </returns>
        /// <exception cref="HandlerNotFound">
        /// </exception>
        public ICommandHandler<TCommand, TResult> ResolveHandler<TCommand, TResult>() where TCommand : ICommand<TResult>
        {
            var cmdType = typeof(TCommand);
            object handlerWrapper;
            if (AnoHandlers.TryGetValue(cmdType, out handlerWrapper))
            {
                var handlerFn = handlerWrapper as Func<TCommand, TResult>;
                if (handlerFn != null)
                {
                    return new AnonymousCommandHandler<TCommand, TResult>(handlerFn);
                }
            }

            var handler = this._serviceProvider.GetService<ICommandHandler<TCommand, TResult>>();
            if (handler == null)
            {
                throw new HandlerNotFound(typeof(TCommand));
            }

            return handler;
        }

        /// <summary>
        ///     The resolve listeners.
        /// </summary>
        /// <typeparam name="TMessage">
        /// </typeparam>
        /// <returns>
        ///     The <see cref="IEnumerable{T}" />.
        /// </returns>
        public IEnumerable<IEventListener<TMessage>> ResolveListeners<TMessage>() where TMessage : IEvent
        {
            var msgType = typeof(TMessage);
            var receivers = this._serviceProvider.GetServices<IEventListener<TMessage>>().ToList();

            List<object> actionWrappers;
            if (AnoReceivers.TryGetValue(msgType, out actionWrappers))
            {
                var anoReceivers =
                    actionWrappers.Where(t => t.GetType() == typeof(Action<TMessage>))
                        .Select(t => new AnonymousEventListener<TMessage>((Action<TMessage>)t));

                receivers.AddRange(anoReceivers);
            }

            return receivers;
        }

        /// <summary>
        ///     The un register anonymous handler.
        /// </summary>
        /// <param name="handler">
        ///     The handler.
        /// </param>
        /// <typeparam name="TCommand">
        /// </typeparam>
        /// <typeparam name="TResult">
        /// </typeparam>
        public void UnRegisterAnoHandler<TCommand, TResult>(Func<TCommand, TResult> handler)
            where TCommand : ICommand<TResult>
        {
            var cmdType = typeof(TCommand);
            object value;
            AnoHandlers.TryRemove(cmdType, out value);
        }

        /// <summary>
        ///     The un register anonymous receiver.
        /// </summary>
        /// <param name="receiver">
        ///     The receiver.
        /// </param>
        /// <typeparam name="TMessage">
        /// </typeparam>
        public void UnRegisterAnoReceiver<TMessage>(Action<TMessage> receiver) where TMessage : IEvent
        {
            var msgType = typeof(TMessage);
            List<object> receivers;
            if (AnoReceivers.TryGetValue(msgType, out receivers))
            {
                receivers.Remove(receiver);
            }
        }
    }
}