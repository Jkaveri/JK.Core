// Copyright (c) Ho Nguyen. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace JKCore.Mediator
{
    /// <summary>
    /// </summary>
    public interface IHandlerResolver
    {
        /// <summary>
        /// </summary>
        IMediatorHandler<TMessage, TResult> ResolveHandler<TMessage, TResult>()
            where TMessage : IMessage<TResult>;

        /// <summary>
        ///     Resolve async command handler
        /// </summary>
        IMediatorHandler<TMessage> ResolveHandler<TMessage>() where TMessage : IMessage;
    }
}