// Copyright (c) Ho Nguyen. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace JKCore.Mediator
{
    using JKCore.Mediator.Events;
    using System.Collections.Generic;

    /// <summary>
    /// </summary>
    public interface IEventListenersProvider
    {
        /// <summary>
        /// </summary>
        /// <typeparam name="TMessage">
        /// </typeparam>
        /// <returns>
        /// </returns>
        IEnumerable<IAsyncEventListener<TMessage>> ResolveAsyncListeners<TMessage>() where TMessage : IAsyncEvent;

        /// <summary>
        /// </summary>
        /// <typeparam name="TMessage">
        /// </typeparam>
        /// <returns>
        /// </returns>
        IEnumerable<IEventListener<TMessage>> ResolveListeners<TMessage>() where TMessage : IEvent;
    }
}