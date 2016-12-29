// Copyright (c) Ho Nguyen. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace JKCore.Utilities
{
    #region

    using System;
    using System.Collections.Generic;

    #endregion

    /// <summary>
    ///     Collection utilities
    /// </summary>
    public static class CollectionUtils
    {
        /// <summary>
        /// </summary>
        /// <typeparam name="TEnum">
        /// </typeparam>
        /// <returns>
        /// </returns>
        public static IEnumerable<TEnum> GetEnumCollection<TEnum>() where TEnum : struct, IConvertible
        {
            var values = Enum.GetValues(typeof(TEnum));
            foreach (TEnum item in values)
            {
                yield return item;
            }
        }
    }
}