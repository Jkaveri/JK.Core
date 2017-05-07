// Copyright (c) Ho Nguyen. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

#endregion

namespace JKCore.Utilities
{
    #region

    #endregion

    /// <summary>
    ///     A utilities class help to perform reflection operation.
    /// </summary>
    public static class ReflectionUtils
    {
        /// <summary>
        ///     Scan assembly of <see cref="Type" />
        /// </summary>
        /// <param name="type">
        ///     The type.
        /// </param>
        /// <returns>
        ///     Collection of type in assembly
        /// </returns>
        public static IEnumerable<Type> AllTypesInAssemblyOf(Type type)
        {
            return GetAssembly(type).GetTypes();
        }

        /// <summary>
        /// </summary>
        /// <typeparam name="T">
        /// </typeparam>
        /// <returns>
        /// </returns>
        public static IEnumerable<Type> AllTypesInAssemblyOf<T>()
        {
            return AllTypesInAssemblyOf(typeof(T));
        }

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
        /// <param name="childType">
        ///     The child type.
        /// </param>
        /// <param name="parentType">
        ///     The parent type.
        /// </param>
        /// <returns>
        /// </returns>
        public static bool IsAssignAbleTo(Type childType, Type parentType)
        {
            return parentType.IsAssignableFrom(childType);
        }

        /// <summary>
        /// </summary>
        /// <param name="type">
        ///     The type.
        /// </param>
        /// <returns>
        /// </returns>
        public static bool IsClass(Type type)
        {
            var typeInfo = type.GetTypeInfo();
            return typeInfo.IsClass;
        }

        /// <summary>
        /// </summary>
        /// <param name="type">
        ///     The type.
        /// </param>
        /// <returns>
        /// </returns>
        public static bool IsStaticClass(Type type)
        {
            var typeInfo = type.GetTypeInfo();
            return typeInfo.IsSealed && typeInfo.IsAbstract;
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

        public static Assembly GetAssembly<T>()
        {
            return GetAssembly(typeof(T));
        }

        public static Assembly GetAssembly(Type type)
        {
            return type.GetTypeInfo().Assembly;
        }
    }
}