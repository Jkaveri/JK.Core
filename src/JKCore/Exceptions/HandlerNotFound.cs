// Copyright (c) Ho Nguyen. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace JKCore.Exceptions
{
    #region

    using System;

    #endregion

    /// <summary>
    /// </summary>
    public class HandlerNotFound : Exception
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="HandlerNotFound" /> class.
        /// </summary>
        /// <param name="cmdType">
        ///     The cmd type.
        /// </param>
        public HandlerNotFound(Type cmdType)
            : base($"Handler for {cmdType.FullName} not found")
        {
            this.CommandType = cmdType;
        }

        /// <summary>
        ///     Gets the command type.
        /// </summary>
        public Type CommandType { get; private set; }
    }
}