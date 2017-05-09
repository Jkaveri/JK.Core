// Copyright (c) Ho Nguyen. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

#region

using System.Collections.Generic;
using JKCore.Mediator.Abstracts;
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
        public MediatorResult(bool successful)
            : this(successful, default(TResult))
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="MediatorResult{TResult}" /> class.
        /// </summary>
        public MediatorResult(bool successful, TResult result) : this(successful, result, null)
        {
        }

        /// <summary>
        ///     Construct mediator result
        /// </summary>
        public MediatorResult(bool successful, TResult result, IEnumerable<ErrorItem> errors)
        {
            Successful = successful;
            Data = result;
            AddErrors(errors);
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
}