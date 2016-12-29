// Copyright (c) Ho Nguyen. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace JK.Core.Mediator.Events
{
    #region

    using System.Threading.Tasks;

    #endregion

    /// <summary>
    /// </summary>
    /// <typeparam name="TMessage">
    /// </typeparam>
    public interface IAsyncEventListener<TMessage> : IAsyncEventListener
        where TMessage : IAsyncEvent
    {
        /// <summary>
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        /// <returns>
        /// </returns>
        Task Handle(TMessage message);
    }

    /// <summary>
    /// </summary>
    public interface IAsyncEventListener
    {
    }
}