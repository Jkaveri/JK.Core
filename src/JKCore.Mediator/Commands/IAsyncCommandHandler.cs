// Copyright (c) Ho Nguyen. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace JKCore.Mediator.Commands
{
    #region

    using System.Threading.Tasks;

    #endregion

    /// <summary>
    /// </summary>
    /// <typeparam name="TCommand">
    /// </typeparam>
    /// <typeparam name="TResult">
    /// </typeparam>
    public interface IAsyncCommandHandler<TCommand, TResult> : ICommandHandler
        where TCommand : IAsyncCommand<TResult>
    {
        /// <summary>
        /// Handle async command.
        /// </summary>
        /// <returns><see cref="ICommandResult{TData}"/></returns>
        Task<ICommandResult<TResult>> Handle(TCommand command);
    }

    /// <summary>
    /// Async command handle
    /// </summary>
    /// <typeparam name="TCommand">Async Command with no return type.</typeparam>
    public interface IAsyncCommandHandler<TCommand> : ICommandHandler where TCommand : IAsyncCommand
    {
        /// <summary>
        /// Handle async command.
        /// </summary>
        /// <returns><see cref="ICommandResult"/></returns>
        Task<ICommandResult> Handle(TCommand command);
    }
}