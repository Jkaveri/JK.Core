// Copyright (c) Ho Nguyen. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace JKCore.Exceptions.Validation
{
    #region

    using System;

    #endregion

    /// <summary>
    ///     The validation exception.
    /// </summary>
    public class ValidationException : Exception
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ValidationException" /> class.
        /// </summary>
        /// <param name="message">
        ///     The message.
        /// </param>
        public ValidationException(string message)
            : base(message)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ValidationException" /> class.
        /// </summary>
        /// <param name="message">
        ///     The message.
        /// </param>
        /// <param name="inner">
        ///     The inner.
        /// </param>
        public ValidationException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}