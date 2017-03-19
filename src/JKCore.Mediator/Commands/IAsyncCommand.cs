// Copyright (c) Ho Nguyen. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace JKCore.Mediator.Commands
{
    /// <summary>
    /// Async command with return value
    /// </summary>
    /// <typeparam name="TResult">A return type</typeparam>
    public interface IAsyncCommand<TResult>
    {
    }

    /// <summary>
    /// Async command with no return value.
    /// </summary>
    public interface IAsyncCommand { }
}