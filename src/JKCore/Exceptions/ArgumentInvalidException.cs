// Copyright (c) Ho Nguyen. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace JKCore.Exceptions
{
    #region

    using System;

    #endregion

    /// <summary>
    ///     Argument invalid exception.
    /// </summary>
    public class ArgumentInvalidException : Exception
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ArgumentInvalidException" /> class.
        /// </summary>
        /// <param name="argName">
        ///     The argument name.
        /// </param>
        /// <param name="reason">
        ///     The reason.
        /// </param>
        /// <param name="innerException">
        ///     The inner exception.
        /// </param>
        public ArgumentInvalidException(string argName, InvalidReason reason, Exception innerException)
            : base($"Argument {argName} is invalid. Reason: {reason}", innerException)
        {
            this.Reason = reason;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ArgumentInvalidException" /> class.
        /// </summary>
        /// <param name="argName">
        ///     The argument name.
        /// </param>
        /// <param name="reason">
        ///     The reason.
        /// </param>
        public ArgumentInvalidException(string argName, InvalidReason reason)
            : this(argName, reason, null)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ArgumentInvalidException" /> class.
        /// </summary>
        /// <param name="argName">
        ///     The argument name.
        /// </param>
        public ArgumentInvalidException(string argName)
            : this(argName, InvalidReason.General, null)
        {
        }

        /// <summary>
        ///     Gets the reason.
        /// </summary>
        public InvalidReason Reason { get; private set; }
    }

    /// <summary>
    ///     Invalid reasons.
    /// </summary>
    [Flags]
    public enum InvalidReason
    {
        /// <summary>
        ///     Null
        /// </summary>
        Null,

        /// <summary>
        ///     Empty
        /// </summary>
        Empty,

        /// <summary>
        ///     Out of range.
        /// </summary>
        OutOfRange,

        /// <summary>
        ///     Others...
        /// </summary>
        General
    }
}