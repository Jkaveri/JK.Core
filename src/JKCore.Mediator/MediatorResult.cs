// Copyright (c) Ho Nguyen. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

#region

using JKCore.Models;

#endregion

namespace JKCore.Mediator
{
    /// <summary>
    /// </summary>
    public class MediatorResult<TResult> : ErroritemContainer, IMediatorResult<TResult>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="MediatorResult{TResult}" /> class.
        /// </summary>
        /// <param name="succeed">
        ///     The succeed.
        /// </param>
        public MediatorResult(bool succeed)
            : this(succeed, default(TResult))
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="MediatorResult{TResult}" /> class.
        /// </summary>
        /// <param name="succeed">
        ///     The succeed.
        /// </param>
        /// <param name="result">
        ///     The result.
        /// </param>
        public MediatorResult(bool succeed, TResult result)
        {
            Successful = succeed;
            Data = result;
        }

        /// <summary>
        ///     Gets the result.
        /// </summary>
        public TResult Data { get; }

        /// <summary>
        ///     Gets a value indicating whether succeed.
        /// </summary>
        public bool Successful { get; }
    }

    /// <summary>
    /// </summary>
    public class MediatorResult : ErroritemContainer, IMediatorResult
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="MediatorResult{TResult}" /> class.
        /// </summary>
        /// <param name="succeed">
        ///     The succeed.
        /// </param>
        public MediatorResult(bool succeed)
        {
            Successful = succeed;
        }

        /// <summary>
        ///     Gets a value indicating whether succeed.
        /// </summary>
        public bool Successful { get; }
    }
}