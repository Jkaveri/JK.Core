// Copyright (c) Ho Nguyen. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace JK.Core.Mediator.Commands
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
        /// </summary>
        /// <param name="command">
        /// The command.
        /// </param>
        /// <returns>
        /// </returns>
        Task<TResult> Handle(TCommand command);
    }
}