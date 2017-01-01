﻿// Copyright (c) Ho Nguyen. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace JKCore.Mediator.Events
{
    /// <summary>
    /// </summary>
    /// <typeparam name="TMessage">
    /// </typeparam>
    public interface IEventListener<TMessage> : IEventListener
        where TMessage : IEvent
    {
        /// <summary>
        /// </summary>
        /// <param name="message">
        ///     The message.
        /// </param>
        void Handle(TMessage message);
    }

    /// <summary>
    /// </summary>
    public interface IEventListener
    {
    }
}