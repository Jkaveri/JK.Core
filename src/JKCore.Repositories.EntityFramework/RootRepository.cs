// Copyright (c) Ho Nguyen. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace JK.Core.Repositories.EntityFramework
{
    #region

    using System.Threading.Tasks;

    using JKCore.Modeling;
    using JKCore.Repositories;

    using Microsoft.EntityFrameworkCore;

    #endregion

    /// <summary>
    /// </summary>
    /// <typeparam name="TEntity">
    /// </typeparam>
    public class RootRepository<TEntity> : RootRepository<TEntity, string>
        where TEntity : AggregateRoot
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RootRepository{TEntity}"/> class.
        /// </summary>
        /// <param name="dbcontext">
        /// The dbcontext.
        /// </param>
        public RootRepository(DbContext dbcontext)
            : base(dbcontext)
        {
        }
    }

    /// <summary>
    /// </summary>
    /// <typeparam name="TEntity">
    /// </typeparam>
    /// <typeparam name="TKey">
    /// </typeparam>
    public class RootRepository<TEntity, TKey> : Repository<TEntity>, IRootRepository<TEntity, TKey>
        where TEntity : class, IAggregateRoot<TKey>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RootRepository{TEntity,TKey}"/> class.
        /// </summary>
        /// <param name="dbcontext">
        /// The dbcontext.
        /// </param>
        public RootRepository(DbContext dbcontext)
            : base(dbcontext)
        {
        }

        /// <summary>
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// </returns>
        public TEntity FindById(TKey id)
        {
            return this.DbSet.Find(id);
        }

        /// <summary>
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// </returns>
        public Task<TEntity> FindByIdAsync(TKey id)
        {
            return this.DbSet.FindAsync(id);
        }
    }
}