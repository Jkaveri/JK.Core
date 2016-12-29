// Copyright (c) Ho Nguyen. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace JKCore.Utilities
{
    #region

    using System;
    using System.Collections;

    #endregion

    /// <summary>
    /// </summary>
    public static class Check
    {
        /// <summary>
        /// </summary>
        /// <param name="arg">
        ///     The arg.
        /// </param>
        /// <param name="argName">
        ///     The arg name.
        /// </param>
        /// <exception cref="ArgumentException">
        /// </exception>
        public static void ArgNotEmpty(object arg, string argName)
        {
            if (IsEmpty(arg))
            {
                throw new ArgumentException($"{argName} should not empty.");
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="arg">
        ///     The arg.
        /// </param>
        /// <param name="argName">
        ///     The arg name.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// </exception>
        public static void ArgNotNull(object arg, string argName)
        {
            if (arg == null)
            {
                throw new ArgumentNullException(argName);
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="arg">
        ///     The arg.
        /// </param>
        /// <param name="argName">
        ///     The arg name.
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
            if (value is string)
            {
                if (((string)value).Length == 0) return true;
            }

            if (value is ICollection)
            {
                var col = (ICollection)value;
                if (col.Count == 0)
                {
                    return true;
                }
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