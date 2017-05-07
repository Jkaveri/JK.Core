// Copyright (c) Ho Nguyen. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using JKCore.Utilities;

#endregion

namespace JKCore.Mediator
{
    /// <summary>
    /// </summary>
    public class Mediator : IMediator
    {
        private readonly IHandlerResolver _handlerResolver;

        /// <summary>
        ///     Initializes a new instance of the <see cref="Mediator" /> class.
        /// </summary>
        public Mediator(IHandlerResolver handlerResolver)
        {
            _handlerResolver = handlerResolver ?? throw new ArgumentNullException(nameof(handlerResolver));
        }

        /// <summary>
        ///     Send command async.
        /// </summary>
        public Task<IMediatorResult<TResult>> Send<TResult>(IMessage<TResult> message,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            Check.ArgNotNull(message, nameof(message));

            object handler = _handlerResolver.Resolve(message.GetType());

            if (handler == null) throw new InvalidOperationException("Handler not found");

            var method = handler.GetType().GetMethod("Process");

            return (Task<IMediatorResult<TResult>>) method.Invoke(handler,
                new object[] {message, cancellationToken});
        }

        /// <summary>
        ///     Send a command.
        /// </summary>
        public Task<IMediatorResult> Send(IMessage message,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            Check.ArgNotNull(message, nameof(message));

            var handler = _handlerResolver.Resolve(message.GetType());

            if (handler == null) throw new InvalidOperationException("Handler not found");

            var method = handler.GetType().GetMethod("Process");
            return (Task<IMediatorResult>) method.Invoke(handler, new object[] {message, cancellationToken});
        }
    }
}