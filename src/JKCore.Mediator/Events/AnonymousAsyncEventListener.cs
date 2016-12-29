// Copyright (c) Ho Nguyen. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace JK.Core.Mediator.Events
{
    #region

    using System;
    using System.Threading.Tasks;

    #endregion

    /// <summary>
    /// </summary>
    /// <typeparam name="TMessage">
    /// </typeparam>
    public class AnonymousAsyncEventListener<TMessage> : IAsyncEventListener<TMessage>
        where TMessage : IAsyncEvent
    {
        private Func<TMessage, Task> _receiver;

        /// <summary>
        /// Initializes a new instance of the <see cref="AnonymousAsyncEventListener{TMessage}"/> class.
        /// </summary>
        /// <param name="receiver">
        /// The receiver.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// </exception>
        public AnonymousAsyncEventListener(Func<TMessage, Task> receiver)
        {
            if (receiver == null)
            {
                throw new ArgumentNullException(nameof(receiver));
            }

            this._receiver = receiver;
        }

        /// <summary>
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        /// <returns>
        /// </returns>
        public Task Handle(TMessage message)
        {
            return this._receiver(message);
        }
    }
}