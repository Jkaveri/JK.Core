// Copyright (c) Ho Nguyen. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace JKCore.Utilities
{
    #region

    using System;
    using System.Collections;

    using JKCore.Exceptions;

    #endregion

    /// <summary>
    /// </summary>
    public static class Check
    {
        /// <summary>
        /// </summary>
        /// <param name="arg">
        ///     The argument.
        /// </param>
        /// <param name="argName">
        ///     The argument name.
        /// </param>
        /// <exception cref="ArgumentException">
        /// </exception>
        public static void ArgNotEmpty(object arg, string argName)
        {
            if (IsEmpty(arg))
            {
                throw new ArgumentInvalidException(argName, InvalidReason.Empty);
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="arg">
        ///     The argument.
        /// </param>
        /// <param name="argName">
        ///     The argument name.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// </exception>
        public static void ArgNotNull(object arg, string argName)
        {
            if (arg == null)
            {
                throw new ArgumentInvalidException(argName, InvalidReason.Null);
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="arg">
        ///     The argument.
        /// </param>
        /// <param name="argName">
        ///     The argument name.
        /// </param>
        public static void ArgNotNullOrEmpty(object arg, string argName)
        {
            ArgNotNull(arg, argName);
            ArgNotEmpty(arg, argName);
        }

        /// <summary>
        /// </summary>
        /// <param name="value">
        ///     The value.
        /// </param>
        /// <returns>
        /// </returns>
        public static bool IsEmpty(object value)
        {
            var s = value as string;
            if (s?.Length == 0)
            {
                return true;
            }

            var collection = value as ICollection;
            var col = collection;
            if (col?.Count == 0)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// </summary>
        /// <param name="value">
        ///     The value.
        /// </param>
        /// <returns>
        /// </returns>
        /// <exception cref="ArgumentException">
        /// </exception>
        public static Guid IsGuid(string value)
        {
            Guid guid;
            if (Guid.TryParse(value, out guid))
            {
                return guid;
            }

            throw new ArgumentException("Guid is invalid");
        }
    }
}