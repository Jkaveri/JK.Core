// Copyright (c) Ho Nguyen. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

#region

using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Reflection;
using JKCore.Mediator.Abstracts;
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
        private static readonly ConcurrentDictionary<Type, Type> Cached = new ConcurrentDictionary<Type, Type>();

        /// <summary>
        ///     The _container.
        /// </summary>
        private readonly IServiceProvider _serviceProvider;

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
            var handler = Resolve(typeof(TMessage));

            if (handler == null)
            {
                throw new HandlerNotFound(typeof(TMessage));
            }

            return (IMediatorHandler<TMessage, TResult>) handler;
        }

        public object Resolve(Type messageType)
        {
            return InnerResolve(messageType);
        }

        private object InnerResolve(Type messageType)
        {
            Type type;

            if (Cached.TryGetValue(messageType, out type) == false)
            {
                type = BuildHandlerType(messageType);
            }

            return _serviceProvider.GetService(type);
        }

        private Type BuildHandlerType(Type messageType)
        {
            var realTypes = GetRealMessageTypes(messageType);

            if (realTypes == null)
            {
                throw new InvalidOperationException("Invalid message type");
            }

            // Make generic IMediatorHandler<TMessage, TResult>
            return typeof(IMediatorHandler<,>).MakeGenericType(realTypes.Item1, realTypes.Item2);
        }

        /// <summary>
        ///     Get real message type and result type.
        ///     Item1 = Message Type, Item2 = result type.
        /// </summary>
        private Tuple<Type, Type> GetRealMessageTypes(Type sourceType)
        {
            var messageType = sourceType;
            var iMessageType = typeof(IMessage);
            var typeInfo = messageType.GetTypeInfo();
            var interfaces =
                typeInfo.ImplementedInterfaces.Where(t => t != iMessageType && iMessageType.IsAssignableFrom(t));

            Type resultType = null;
            var found = false;

            foreach (var @interface in interfaces)
            {
                if (@interface.IsConstructedGenericType)
                {
                    var genericType = @interface.GetGenericTypeDefinition();
                    if (genericType == typeof(IQuery<>) || genericType == typeof(IMessage<>))
                    {
                        found = true;
                        resultType = @interface.GenericTypeArguments[0];
                    }
                }
                else if (iMessageType.IsAssignableFrom(@interface))
                {
                    messageType = @interface;
                }
            }
            if (found)
            {
                return new Tuple<Type, Type>(messageType, resultType);
            }

            return null;
        }
    }
}