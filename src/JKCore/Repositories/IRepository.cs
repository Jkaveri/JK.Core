// Copyright (c) Ho Nguyen. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace JKCore.Repositories
{
    #region

    using System.Linq;

    #endregion

    /// <summary>
    /// </summary>
    /// <typeparam name="T">
    /// </typeparam>
    public interface IRepository<T> : IRepository
        where T : class
    {
        /// <summary>
        /// </summary>
        /// <param name="entity">
        ///     The entity.
        /// </param>
        void Delete(T entity);

        /// <summary>
        /// </summary>
        /// <param name="entity">
        ///     The entity.
        /// </param>
        void Insert(T entity);

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        IQueryable<T> Select();

        /// <summary>
        /// </summary>
        /// <param name="entity">
        ///     The entity.
        /// </param>
        void Update(T entity);
    }

    /// <summary>
    /// </summary>
    public interface IRepository
    {
    }
}