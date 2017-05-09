// Copyright (c) Ho Nguyen. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using System;

namespace JKCore.Mediator.Abstracts
{
    /// <summary>
    /// </summary>
    public interface IHandlerResolver
    {
        /// <summary>
        /// </summary>
        IMediatorHandler<TMessage, TResult> ResolveHandler<TMessage, TResult>()
            where TMessage : IMessage<TResult>;

        object Resolve(Type messageType);
    }
}