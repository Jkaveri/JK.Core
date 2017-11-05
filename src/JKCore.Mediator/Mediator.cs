// Copyright (c) Ho Nguyen. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

#region

using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;
using JKCore.Mediator.Abstracts;
using JKCore.Mediator.Internal;
using JKCore.Utilities;

#endregion

namespace JKCore.Mediator
{
    /// <summary>
    /// </summary>
    public class Mediator : IMediator
    {
        private static readonly ConcurrentDictionary<Type, object> Handlers = new ConcurrentDictionary<Type, object>();
        private readonly FilterManager _filterManager;
        private readonly IHandlerResolver _handlerResolver;

        /// <summary>
        ///     Initializes a new instance of the <see cref="Mediator" /> class.
        /// </summary>
        public Mediator(IHandlerResolver handlerResolver, FilterManager filterManager)
        {
            _filterManager = filterManager ?? throw new ArgumentNullException(nameof(filterManager));
            _handlerResolver = handlerResolver ?? throw new ArgumentNullException(nameof(handlerResolver));
        }

        /// <summary>
        ///     Send command async.
        /// </summary>
        public Task<IMediatorResult<TResult>> Send<TResult>(IMessage<TResult> message,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            Check.ArgNotNull(message, nameof(message));

            var msgType = message.GetType();
            var implement =
                (MediatorHandlerImpl<TResult>) Handlers.GetOrAdd(msgType,
                    (key) => Activator.CreateInstance(
                        typeof(MediatorHandlerImpl<,>).MakeGenericType(key, typeof(TResult))));

            return implement.Handle(message, _handlerResolver, _filterManager, cancellationToken);
        }
    }
}