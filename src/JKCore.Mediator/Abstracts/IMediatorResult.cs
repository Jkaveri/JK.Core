// Copyright (c) Ho Nguyen. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

#region

using JKCore.Models;

#endregion

namespace JKCore.Mediator.Abstracts
{
    /// <summary>
    ///     Message resul
    /// </summary>
    public interface IMediatorResult<out TData> : IErrorItemContainer
    {
        /// <summary>
        ///     Gets the result.
        /// </summary>
        TData Data { get; }

        /// <summary>
        ///     Gets a value indicating whether succeed.
        /// </summary>
        bool Successful { get; }
    }
}