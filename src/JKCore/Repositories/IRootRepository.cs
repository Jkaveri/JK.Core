// Copyright (c) Ho Nguyen. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace JKCore.Repositories
{
    #region

    using System.Threading.Tasks;

    using JKCore.Modeling;

    #endregion

    /// <summary>
    /// </summary>
    /// <typeparam name="TEntity">
    /// </typeparam>
    /// <typeparam name="TKey">
    /// </typeparam>
    public interface IRootRepository<TEntity, TKey> : IRepository<TEntity>
        where TEntity : class, IAggregateRoot<TKey>
    {
        /// <summary>
        /// </summary>
        /// <param name="id">
        ///     The id.
        /// </param>
        /// <returns>
        /// </returns>
        TEntity FindById(TKey id);

        /// <summary>
        /// </summary>
        /// <param name="id">
        ///     The id.
        /// </param>
        /// <returns>
        /// </returns>
        Task<TEntity> FindByIdAsync(TKey id);
    }
}