// Copyright (c) Ho Nguyen. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace JKCore.Mediator
{
    using JKCore.Mediator.Commands;

    /// <summary>
    /// </summary>
    public interface ICommandHandlerProvider
    {
        /// <summary>
        /// </summary>
        /// <typeparam name="TCommand">
        /// </typeparam>
        /// <typeparam name="TResult">
        /// </typeparam>
        /// <returns>
        /// </returns>
        IAsyncCommandHandler<TCommand, TResult> ResolveAsyncHandler<TCommand, TResult>()
            where TCommand : IAsyncCommand<TResult>;

        /// <summary>
        /// Resolve async command handler
        /// </summary>
        IAsyncCommandHandler<TCommand> ResolveAsyncHandler<TCommand>() where TCommand : IAsyncCommand;

    }
}