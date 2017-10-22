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
    public interface IEntityRepository<TEntity, TKey> : IRepository<TEntity>
        where TEntity : class, IEntity<TKey>
    {
        /// <summary>
        /// Find entity by id.
        /// </summary>
        Task<TEntity> FindByIdAsync(TKey id);
    }
}