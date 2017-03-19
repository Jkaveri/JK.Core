// Copyright (c) Ho Nguyen. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace JKCore.Mediator.Commands
{
    /// <summary>
    /// </summary>
    /// <typeparam name="TCommand">
    /// </typeparam>
    /// <typeparam name="TResult">
    /// </typeparam>
    public interface ICommandHandler<TCommand, TResult> : ICommandHandler
        where TCommand : ICommand<TResult>
    {
        /// <summary>
        /// </summary>
        /// <param name="command">
        /// The command.
        /// </param>
        /// <returns>
        /// </returns>
        ICommandResult<TResult> Handle(TCommand command);
    }

    /// <summary>
    /// </summary>
    /// <typeparam name="TCommand">
    /// </typeparam>
    public interface ICommandHandler<TCommand> : ICommandHandler
        where TCommand : ICommand
    {
        /// <summary>
        /// </summary>
        /// <param name="command">
        /// The command.
        /// </param>
        /// <returns>
        /// </returns>
        ICommandResult Handle(TCommand command);
    }

    /// <summary>
    /// </summary>
    public interface ICommandHandler
    {
    }
}