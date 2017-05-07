// Copyright (c) Ho Nguyen. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using JKCore.Mediator.Events;

#endregion

namespace JKCore.Mediator
{
    /// <summary>
    /// </summary>
    public class Mediator : IMediator
    {
        private readonly IHandlerResolver _handlerResolver;
        private readonly IEventListenersProvider _listenersProvider;

        /// <summary>
        ///     Initializes a new instance of the <see cref="Mediator" /> class.
        /// </summary>
        public Mediator(IHandlerResolver handlerResolver, IEventListenersProvider listenersProvider)
        {
            _handlerResolver = handlerResolver ?? throw new ArgumentNullException(nameof(handlerResolver));
            _listenersProvider = listenersProvider ?? throw new ArgumentNullException(nameof(listenersProvider));
        }

        /// <summary>
        ///     Publish event async.
        /// </summary>
        public Task PublishAsync<TMessage>(TMessage message,
            CancellationToken cancellationToken = default(CancellationToken)) where TMessage : IAsyncEvent
        {
            var receivers = _listenersProvider.ResolveAsyncListeners<TMessage>();
            var asyncEventListeners = receivers as IList<IAsyncEventListener<TMessage>> ?? receivers.ToList();
            if (asyncEventListeners.Any())
            {
                return Task.WhenAll(asyncEventListeners.Select(t => t.Handle(message)));
            }

            return Task.Delay(0, cancellationToken);
        }

        /// <summary>
        ///     Send command async.
        /// </summary>
        public Task<IMediatorResult<TResult>> SendAsync<TResult>(IMessage<TResult> command,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var commandType = command.GetType();
            var method = _handlerResolver.GetType()
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

            var handler = method.Invoke(_handlerResolver, null);

            if (handler != null)
            {
                method = handler.GetType().GetMethod("Process");
                return (Task<IMediatorResult<TResult>>) method.Invoke(handler,
                    new object[] {command, cancellationToken});
            }

            throw new InvalidOperationException("Handler not found");
        }

        /// <summary>
        ///     Send a command.
        /// </summary>
        public Task<IMediatorResult> SendAsync(IMessage command,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var commandType = command.GetType();
            var method = _handlerResolver.GetType()
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

            var handler = method.Invoke(_handlerResolver, null);

            if (handler != null)
            {
                method = handler.GetType().GetMethod("Process");
                return (Task<IMediatorResult>) method.Invoke(handler, new object[] {command, cancellationToken});
            }

            throw new InvalidOperationException("Handler not found");
        }
    }
}