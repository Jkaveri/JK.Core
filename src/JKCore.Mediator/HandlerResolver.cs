// Copyright (c) Ho Nguyen. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

#region

using System;
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
    }
}