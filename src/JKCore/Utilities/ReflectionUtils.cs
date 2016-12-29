// Copyright (c) Ho Nguyen. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace JKCore.Utilities
{
    #region

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    #endregion

    /// <summary>
    ///     A utilities class help to perform reflection operation.
    /// </summary>
    public static class ReflectionUtils
    {
        /// <summary>
        ///     Copy a object to another <typeparamref name="T" />
        /// </summary>
        /// <typeparam name="T">A target type want to copy</typeparam>
        /// <param name="src">A source object</param>
        /// <returns>
        ///     <typeparamref name="T" />
        /// </returns>
        public static T CopyTo<T>(object src) where T : class, new()
        {
            if (src == null)
            {
                return null;
            }

            var destType = typeof(T);
            var srcType = src.GetType();
            var dest = Activator.CreateInstance<T>();
            var destProps = destType.GetProperties();

            for (var i = 0; i < destProps.Length; i++)
            {
                var prop = srcType.GetProperty(destProps[i].Name);
                if (prop != null && prop.DeclaringType == destProps[i].DeclaringType)
                {
                    destProps[i].SetValue(dest, prop.GetValue(src));
                }
            }

            return dest;
        }

        /// <summary>
        /// </summary>
        /// <param name="data">
        ///     The data.
        /// </param>
        /// <returns>
        /// </returns>
        public static IEnumerable<KeyValuePair<string, string>> ObjectToKeyValuePairs(object data)
        {
            if (data == null)
            {
                return new KeyValuePair<string, string>[0];
            }

            var type = data.GetType();
            var properties = type.GetProperties();

            return
                properties.Select(
                    t => new KeyValuePair<string, string>(t.Name, t.GetGetMethod().Invoke(data, null)?.ToString()));
        }
    }
}