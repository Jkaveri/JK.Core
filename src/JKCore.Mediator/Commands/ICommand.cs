// Copyright (c) Ho Nguyen. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace JKCore.Mediator.Commands
{
    /// <summary>
    /// A command that return a result.
    /// </summary>
    /// <typeparam name="TResult">
    /// A result type
    /// </typeparam>
    public interface ICommand<TResult>
    {
    }

    /// <summary>
    /// A command that return void.
    /// </summary>
    public interface ICommand { }
}