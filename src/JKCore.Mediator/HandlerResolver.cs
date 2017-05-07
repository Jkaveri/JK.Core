// Copyright (c) Ho Nguyen. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

#region

using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Reflection;
using JKCore.Mediator.Exceptions;
using Microsoft.Extensions.DependencyInjection;

#endregion

namespace JKCore.Mediator
{
    /// <summary>
    ///     Commmand handler.
    /// </summary>
    public class HandlerResolver : IHandlerResolver
    {
        private readonly ConcurrentDictionary<Type, Type> _cached = new ConcurrentDictionary<Type, Type>();

        /// <summary>
        ///     The _container.
        /// </summary>
        private readonly IServiceProvider _serviceProvider;

        /// <summary>
        ///     Initializes a new instance of the <see cref="EventListenersProvider" /> class.
        /// </summary>
        public HandlerResolver(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        /// <summary>
        ///     The resolve async handler.
        /// </summary>
        public IMediatorHandler<TMessage, TResult> ResolveHandler<TMessage, TResult>()
            where TMessage : IMessage<TResult>
        {
            var handler = _serviceProvider.GetService<IMediatorHandler<TMessage, TResult>>();
            if (handler == null)
            {
                throw new HandlerNotFound(typeof(TMessage));
            }

            return handler;
        }

        /// <summary>
        ///     Resolve async command handler.
        /// </summary>
        public IMediatorHandler<TMessage> ResolveHandler<TMessage>() where TMessage : IMessage
        {
            var handler = _serviceProvider.GetService<IMediatorHandler<TMessage>>();
            if (handler == null)
            {
                throw new HandlerNotFound(typeof(TMessage));
            }

            return handler;
        }

        public object Resolve(Type messageType)
        {
            return InnerResolve(messageType);
        }

        private object InnerResolve(Type messageType)
        {
            Type type;

            if (_cached.TryGetValue(messageType, out type) == false)
            {
                type = BuildHandlerType(messageType);
            }

            return _serviceProvider.GetService(type);
        }

        private Type BuildHandlerType(Type messageType)
        {
            var typeInfo = messageType.GetTypeInfo();

            var interfaceType =
                typeInfo.ImplementedInterfaces.FirstOrDefault(
                    t => typeof(IMessage<>).IsAssignableFrom(t) || typeof(IMessage).IsAssignableFrom(t));

            if (interfaceType == null)
            {
                throw new InvalidOperationException("Invalid message");
            }

            Type resultType = null;
            if (interfaceType.GetTypeInfo().GenericTypeArguments.Length > 0)
            {
                resultType = interfaceType.GetTypeInfo().GenericTypeArguments[0];
            }

            var type = resultType != null

                // Make generic IMediatorHandler<TMessage, TResult>
                ? typeof(IMediatorHandler<,>).MakeGenericType(messageType, resultType)

                // Make generic IMediatorHandler<TMessage>
                : typeof(IMediatorHandler<>).MakeGenericType(messageType);

            return type;
        }
    }
}