// Copyright (c) Ho Nguyen. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace JK.Core.Mediator.Events
{
    #region

    using System;

    #endregion

    /// <summary>
    /// </summary>
    /// <typeparam name="TMessage">
    /// </typeparam>
    public class AnonymousEventListener<TMessage> : IEventListener<TMessage>
        where TMessage : IEvent
    {
        private Action<TMessage> _receiver;

        /// <summary>
        /// Initializes a new instance of the <see cref="AnonymousEventListener{TMessage}"/> class.
        /// </summary>
        /// <param name="receiver">
        /// The receiver.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// </exception>
        public AnonymousEventListener(Action<TMessage> receiver)
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
        public void Handle(TMessage message)
        {
            this._receiver(message);
        }
    }
}