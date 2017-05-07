// Copyright (c) Ho Nguyen. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

#region

using System;

#endregion

namespace JKCore.Mediator.Exceptions
{
    /// <summary>
    ///     QU
    /// </summary>
    public class QueryProcessorNotFound : Exception
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="QueryProcessorNotFound" /> class.
        /// </summary>
        /// <param name="queryType">
        ///     The cmd type.
        /// </param>
        public QueryProcessorNotFound(Type queryType)
            : base($"Handler for {queryType.FullName} not found")
        {
            QueryType = queryType;
        }

        /// <summary>
        ///     Gets the command type.
        /// </summary>
        public Type QueryType { get; private set; }
    }
}