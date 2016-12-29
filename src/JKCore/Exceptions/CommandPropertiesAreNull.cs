// Copyright (c) Ho Nguyen. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace JKCore.Exceptions
{
    #region

    using System;

    #endregion

    /// <summary>
    /// </summary>
    public class CommandPropertiesAreNull : Exception
    {
        /// <summary>
        /// </summary>
        /// <param name="properties"></param>
        public CommandPropertiesAreNull(params string[] properties)
            : base($"All {string.Join(",", properties)} are required.")
        {
        }
    }
}