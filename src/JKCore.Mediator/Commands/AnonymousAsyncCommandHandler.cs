// Copyright (c) Ho Nguyen. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace JKCore.Mediator.Commands
{
    #region

    using System;
    using System.Threading.Tasks;

    #endregion

    /// <summary>
    /// </summary>
    /// <typeparam name="TCommand">
    /// </typeparam>
    /// <typeparam name="TResult">
    /// </typeparam>
    public class AnonymousAsyncCommandHandler<TCommand, TResult> : AsyncCommandHandler<TCommand, TResult>
        where TCommand : IAsyncCommand<TResult>
    {
        private readonly Func<TCommand, Task<ICommandResult<TResult>>> _handler;

        /// <summary>
        /// Initializes a new instance of the <see cref="AnonymousAsyncCommandHandler{TCommand,TResult}"/> class.
        /// </summary>
        /// <param name="handler">
        /// The handler.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// </exception>
        public AnonymousAsyncCommandHandler(Func<TCommand, Task<ICommandResult<TResult>>> handler)
        {
            this._handler = handler ?? throw new ArgumentNullException(nameof(handler));
        }

        /// <summary>
        /// </summary>
        /// <param name="command">
        /// The command.
        /// </param>
        /// <returns>
        /// </returns>
        public override Task<ICommandResult<TResult>> Handle(TCommand command)
        {
            return this._handler(command);
        }
    }

    /// <summary>
    /// Anonymous async command handler
    /// </summary>
    /// <typeparam name="TCommand"></typeparam>
    public class AnonymousAsyncCommandHandler<TCommand> : AsyncCommandHandler<TCommand>
       where TCommand : IAsyncCommand
    {
        private readonly Func<TCommand, Task<ICommandResult>> _handler;

        /// <summary>
        /// Initializes a new instance of the <see cref="AnonymousAsyncCommandHandler{TCommand}"/> class.
        /// </summary>
        /// <param name="handler">
        /// The handler.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// </exception>
        public AnonymousAsyncCommandHandler(Func<TCommand, Task<ICommandResult>> handler)
        {
            this._handler = handler ?? throw new ArgumentNullException(nameof(handler));
        }

        /// <summary>
        /// </summary>
        /// <param name="command">
        /// The command.
        /// </param>
        /// <returns>
        /// </returns>
        public override Task<ICommandResult> Handle(TCommand command)
        {
            return this._handler(command);
        }
    }
}