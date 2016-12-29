// Copyright (c) Ho Nguyen. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace JK.Core.Repositories.EntityFramework
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
            if (dbcontext == null)
            {
                throw new ArgumentNullException(nameof(dbcontext));
            }

            this.DbContext = dbcontext;
            this.DbSet = this.DbContext.Set<TEntity>();
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
            this.DbContext.Entry(entity).State = EntityState.Deleted;
            this.DbSet.Attach(entity);
        }

        /// <summary>
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        public void Insert(TEntity entity)
        {
            this.DbContext.Entry(entity).State = EntityState.Added;
            this.DbSet.Attach(entity);
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public IQueryable<TEntity> Select()
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
            this.DbContext.Entry(entity).State = EntityState.Modified;
            this.DbSet.Attach(entity);
        }
    }
}