// Copyright (c) Ho Nguyen. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace JK.Core.Mediator.Commands
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
        TResult Handle(TCommand command);
    }

    /// <summary>
    /// </summary>
    public interface ICommandHandler
    {
    }
}