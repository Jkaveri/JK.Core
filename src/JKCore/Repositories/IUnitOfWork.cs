// Copyright (c) Ho Nguyen. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace JKCore.Repositories
{
    #region

    using System.Threading;
    using System.Threading.Tasks;

    #endregion

    /// <summary>
    ///     Unit of work
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        ///     Save all changes
        /// </summary>
        void SaveChanges();

        /// <summary>
        ///     Save all changes async.
        /// </summary>
        Task SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}