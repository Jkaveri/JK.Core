// Copyright (c) Ho Nguyen. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

#region

using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using JKCore.Mediator.Abstracts;
using JKCore.Utilities;

#endregion

namespace JKCore.Mediator
{
    /// <summary>
    /// </summary>
    public class Mediator : IMediator
    {
        private readonly FilterManager _filterManager;
        private readonly IHandlerResolver _handlerResolver;
        private MethodInfo _cachedMethodInfo;

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
        public async Task<IMediatorResult<TResult>> Send<TResult>(IMessage<TResult> message,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            Check.ArgNotNull(message, nameof(message));

            var handler = _handlerResolver.Resolve(message.GetType());

            if (handler == null) throw new InvalidOperationException("Handler not found");

            var messageType = message.GetType();
            var resultType = typeof(TResult);

            var methodInfo = _filterManager.GetType().GetMethod("ApplyFilters");
            return await (Task<IMediatorResult<TResult>>) methodInfo.MakeGenericMethod(messageType, resultType)
                .Invoke(_filterManager, new[] {handler, message, cancellationToken});
        }
    }
}