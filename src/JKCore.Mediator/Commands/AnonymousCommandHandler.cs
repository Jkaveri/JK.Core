// Copyright (c) Ho Nguyen. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace JK.Core.Mediator.Commands
{
    #region

    using System;

    #endregion

    /// <summary>
    /// </summary>
    /// <typeparam name="TCommand">
    /// </typeparam>
    /// <typeparam name="TResult">
    /// </typeparam>
    public class AnonymousCommandHandler<TCommand, TResult> : ICommandHandler<TCommand, TResult>
        where TCommand : ICommand<TResult>
    {
        private Func<TCommand, TResult> _handler;

        /// <summary>
        /// Initializes a new instance of the <see cref="AnonymousCommandHandler{TCommand,TResult}"/> class.
        /// </summary>
        /// <param name="handler">
        /// The handler.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// </exception>
        public AnonymousCommandHandler(Func<TCommand, TResult> handler)
        {
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            this._handler = handler;
        }

        /// <summary>
        /// </summary>
        /// <param name="command">
        /// The command.
        /// </param>
        /// <returns>
        /// </returns>
        public TResult Handle(TCommand command)
        {
            return this._handler(command);
        }
    }
}