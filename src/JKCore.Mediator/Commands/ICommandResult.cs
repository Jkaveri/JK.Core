// Copyright (c) Ho Nguyen. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace JKCore.Mediator.Commands
{
    #region

    using JKCore.Models;

    #endregion

    /// <summary>
    /// </summary>
    public interface ICommandResult<out TData> : IErrorItemContainer
    {
        /// <summary>
        /// Gets the result.
        /// </summary>
        TData Data { get; }

        /// <summary>
        ///     Gets a value indicating whether succeed.
        /// </summary>
        bool Succeed { get; }
    }
}