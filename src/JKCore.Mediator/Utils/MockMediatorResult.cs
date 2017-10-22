// Copyright (c) Ho Nguyen. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

#region

using System;
using JKCore.Mediator.Abstracts;

#endregion

namespace JKCore.Mediator.Utils
{
    /// <summary>
    ///     A utils that help you create a command result in a test method.
    /// </summary>
    public static class MockMediatorResult
    {
        /// <summary>
        ///     Create failure result.
        /// </summary>
        public static IMediatorResult<TResult> Failure<TResult>()
        {
            return new MediatorResult<TResult>(false);
        }

        /// <summary>
        ///     Create failure result with a message.
        /// </summary>
        public static IMediatorResult<TResult> Failure<TResult>(string message)
        {
            var result = Failure<TResult>();
            result.AddError(message);
            return result;
        }

        /// <summary>
        ///     Create failure result with a message and an exception.
        /// </summary>
        public static IMediatorResult<TResult> Failure<TResult>(string message, Exception exception)
        {
            var result = Failure<TResult>();
            result.AddError(message, exception);
            return result;
        }

        /// <summary>
        ///     Create failure result with an exception.
        /// </summary>
        public static IMediatorResult<TResult> Failure<TResult>(Exception exception)
        {
            var result = Failure<TResult>();
            result.AddError(exception);
            return result;
        }

        /// <summary>
        ///     Create a success result.
        /// </summary>
        public static IMediatorResult<TResult> Success<TResult>(TResult result)
        {
            return new MediatorResult<TResult>(true, result);
        }

        /// <summary>
        ///     Create success result.
        /// </summary>
        public static IMediatorResult<TResult> Success<TResult>()
        {
            return new MediatorResult<TResult>(true);
        }
    }
}