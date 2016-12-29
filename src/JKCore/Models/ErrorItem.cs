// Copyright (c) Ho Nguyen. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace JKCore.Models
{
    #region

    using System;

    #endregion

    /// <summary>
    ///     The error item.
    /// </summary>
    public class ErrorItem
    {
        /// <summary>
        ///     Construct <see cref="ErrorItem" /> with <see cref="string" /> message
        /// </summary>
        /// <param name="message">Error message.</param>
        public ErrorItem(string message)
            : this(message, null)
        {
        }

        /// <summary>
        ///     Construct <see cref="ErrorItem" /> with <see cref="string" /> message and <see cref="System.Exception" />
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <param name="exception">Error exception.</param>
        public ErrorItem(string message, Exception exception)
        {
            this.Message = message;
            this.Exception = exception;
        }

        /// <summary>
        ///     Construct <see cref="ErrorItem" /> with <see cref="System.Exception" />
        /// </summary>
        /// <param name="exception">Error Exception.</param>
        public ErrorItem(Exception exception)
            : this(null, exception)
        {
        }

        /// <summary>
        ///     Gets or sets the exception.
        /// </summary>
        public Exception Exception { get; set; }

        /// <summary>
        ///     Gets or sets the message.
        /// </summary>
        public string Message { get; set; }
    }
}