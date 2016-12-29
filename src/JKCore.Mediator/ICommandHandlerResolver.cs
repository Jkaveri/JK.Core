// Copyright (c) Ho Nguyen. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace JK.Core.Mediator
{
    #region

    using JK.Core.Mediator.Commands;

    #endregion

    /// <summary>
    /// </summary>
    public interface ICommandHandlerResolver
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
        /// </summary>
        /// <typeparam name="TCommand">
        /// </typeparam>
        /// <typeparam name="TResult">
        /// </typeparam>
        /// <returns>
        /// </returns>
        ICommandHandler<TCommand, TResult> ResolveHandler<TCommand, TResult>() where TCommand : ICommand<TResult>;
    }
}