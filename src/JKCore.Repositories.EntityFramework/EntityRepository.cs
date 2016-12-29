// Copyright (c) Ho Nguyen. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace JK.Core.Repositories.EntityFramework
{
    #region

    using System;
    using System.Threading.Tasks;

    using JKCore.Modeling;
    using JKCore.Repositories;

    using Microsoft.EntityFrameworkCore;

    #endregion

    /// <summary>
    /// </summary>
    /// <typeparam name="TEntity">
    /// </typeparam>
    public abstract class EntityRepository<TEntity> : EntityRepository<TEntity, string>
        where TEntity : Entity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EntityRepository{TEntity}"/> class.
        /// </summary>
        /// <param name="dbcontext">
        /// The dbcontext.
        /// </param>
        public EntityRepository(DbContext dbcontext)
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
    public abstract class EntityRepository<TEntity, TKey> : Repository<TEntity>, IEntityRepository<TEntity, TKey>
        where TEntity : Entity<TKey>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EntityRepository{TEntity,TKey}"/> class.
        /// </summary>
        /// <param name="dbcontext">
        /// The dbcontext.
        /// </param>
        public EntityRepository(DbContext dbcontext)
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
        /// <exception cref="NotImplementedException">
        /// </exception>
        public TEntity GetById(TKey id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public Task<TEntity> GetByIdAsync(TKey id)
        {
            throw new NotImplementedException();
        }
    }
}