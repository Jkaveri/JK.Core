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
    /// </summary>
    public class TypeCollector
    {
        private IEnumerable<Type> _types;

        private TypeCollector(IEnumerable<Type> types)
        {
            this._types = types;
        }

        /// <summary>
        /// </summary>
        public IEnumerable<Type> Types => this._types;

        /// <summary>
        /// </summary>
        /// <param name="types">
        ///     The types.
        /// </param>
        /// <returns>
        /// </returns>
        public static TypeCollector Create(IEnumerable<Type> types)
        {
            return new TypeCollector(types);
        }

        /// <summary>
        /// </summary>
        /// <param name="type">
        ///     The type.
        /// </param>
        /// <returns>
        /// </returns>
        public static TypeCollector Scan(Type type)
        {
            return Create(ReflectionUtils.AllTypesInAssemblyOf(type));
        }

        /// <summary>
        /// </summary>
        /// <typeparam name="T">
        /// </typeparam>
        /// <returns>
        /// </returns>
        public static TypeCollector Scan<T>()
        {
            return Create(ReflectionUtils.AllTypesInAssemblyOf<T>());
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public TypeCollector AllClasses()
        {
            this._types = this._types.Where(t => !t.GetTypeInfo().IsInterface && !t.GetTypeInfo().IsValueType);
            return this;
        }

        /// <summary>
        /// </summary>
        /// <typeparam name="T">
        /// </typeparam>
        /// <returns>
        /// </returns>
        public TypeCollector Ignore<T>()
        {
            return this.Ignore(typeof(T));
        }

        /// <summary>
        /// </summary>
        /// <param name="type">
        ///     The type.
        /// </param>
        /// <returns>
        /// </returns>
        public TypeCollector Ignore(Type type)
        {
            if (type.GetTypeInfo().IsInterface || type.GetTypeInfo().IsAbstract)
            {
                this._types = this._types.Where(t => t != type && !type.IsAssignableFrom(t));
            }
            else
            {
                this._types = this._types.Where(t => t != type);
            }

            return this;
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public TypeCollector IgnoreStaticClasses()
        {
            this._types = this._types.Where(t => !ReflectionUtils.IsStaticClass(t));
            return this;
        }

        /// <summary>
        /// </summary>
        /// <typeparam name="T">
        /// </typeparam>
        /// <returns>
        /// </returns>
        public TypeCollector ImplementationOf<T>() where T : class
        {
            return this.ImplementationOf(typeof(T));
        }

        /// <summary>
        /// </summary>
        /// <param name="type">
        ///     The type.
        /// </param>
        /// <returns>
        /// </returns>
        public TypeCollector ImplementationOf(Type type)
        {
            this._types = this._types.Where(t => ReflectionUtils.IsAssignAbleTo(t, type));
            return this;
        }

        /// <summary>
        /// </summary>
        /// <param name="types">
        /// The types.
        /// </param>
        /// <returns>
        /// </returns>
        public TypeCollector ImplementationOf(IEnumerable<Type> types)
        {
            this._types = this._types.Where(t => types.Any(@abstract => @abstract.IsAssignableFrom(t)));
            return this;
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public List<Type> ToList()
        {
            return this._types.ToList();
        }
    }
}