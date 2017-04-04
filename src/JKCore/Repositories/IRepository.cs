// Copyright (c) Ho Nguyen. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace JKCore.Repositories
{
    #region

    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    #endregion

    /// <summary>
    /// </summary>
    /// <typeparam name="T">
    /// </typeparam>
    public interface IRepository<T> : IRepository
        where T : class
    {
        /// <summary>
        /// Delete entity.
        /// </summary>
        Task DeleteAsync(T entity, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Insert entity.
        /// </summary>
        Task InsertAsync(T entity, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Get IQueryable{T}
        /// </summary>
        IQueryable<T> GetQueryable();

        /// <summary>
        /// Update entity.
        /// </summary>
        Task UpdateAsync(T entity, CancellationToken cancellationToken = default(CancellationToken));
    }

    /// <summary>
    /// </summary>
    public interface IRepository
    {
    }
}