// Copyright (c) Ho Nguyen. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

#region

using System.Threading.Tasks;

#endregion

namespace JKCore.Mediator.Events
{
    #region

    #endregion

    /// <summary>
    /// </summary>
    /// <typeparam name="TMessage">
    /// </typeparam>
    public interface IAsyncEventListener<TMessage> : IEventListener
        where TMessage : IAsyncEvent
    {
        /// <summary>
        /// </summary>
        /// <param name="message">
        ///     The message.
        /// </param>
        /// <returns>
        /// </returns>
        Task Handle(TMessage message);
    }
}