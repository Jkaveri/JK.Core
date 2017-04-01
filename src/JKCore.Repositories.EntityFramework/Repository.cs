// Copyright (c) Ho Nguyen. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace JKCore.Repositories.EntityFramework
{
    #region

    using System;
    using System.Linq;

    using JKCore.Repositories;

    using Microsoft.EntityFrameworkCore;

    #endregion

    /// <summary>
    ///     Implement <see cref="IRepository" />
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <seealso cref="JK.Core.Domain.Repositories.IRepository{TEntity}" />
    public abstract class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Repository{TEntity}"/> class.
        /// </summary>
        /// <param name="dbcontext">
        /// The dbcontext.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// </exception>
        protected Repository(DbContext dbcontext)
        {
            this.DbContext = dbcontext ?? throw new ArgumentNullException(nameof(dbcontext));
            this.DbSet = DbContext.Set<TEntity>();
        }

        /// <summary>
        /// Gets the db context.
        /// </summary>
        protected DbContext DbContext { get; private set; }

        /// <summary>
        /// Gets the db set.
        /// </summary>
        protected DbSet<TEntity> DbSet { get; private set; }

        /// <summary>
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        public void Delete(TEntity entity)
        {
            var entry = this.DbContext.Entry(entity);
            if (entry.State != EntityState.Deleted)
                entry.State = EntityState.Deleted;
            else
            {
                DbSet.Attach(entity);
                DbSet.Remove(entity);
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        public void Insert(TEntity entity)
        {
            // get tracking entry.
            var entry = this.DbContext.Entry(entity);

            // check entry state.
            if (entry.State != EntityState.Detached)
            {
                // change state to added.
                entry.State = EntityState.Added;
            }
            else
            {
                // add to entities set.
                DbSet.Add(entity);
            }
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public IQueryable<TEntity> GetQueryable()
        {
            return this.DbSet;
        }

        /// <summary>
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        public void Update(TEntity entity)
        {
            var entry = DbContext.Entry(entity);

            switch (entry.State)
            {
                case EntityState.Detached:
                    DbSet.Attach(entity);
                    break;
                case EntityState.Unchanged:
                    entry.State = EntityState.Modified;
                    break;
                default:
                    break;
            }
        }        
    }
}