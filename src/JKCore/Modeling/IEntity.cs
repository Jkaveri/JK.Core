// Copyright (c) Ho Nguyen. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace JKCore.Modeling
{
    #region

    using System;

    #endregion

    /// <summary>
    ///     An interface represent for an entity with a Key.
    /// </summary>
    public interface IEntity<TKey> : IEntity, IEquatable<IEntity<TKey>>
    {
        /// <summary>
        ///     Gets or sets CreatedDate
        /// </summary>
        DateTimeOffset CreatedDate { get; set; }

        /// <summary>
        ///     Gets or sets Id
        /// </summary>
        TKey Id { get; set; }

        /// <summary>
        ///     Gets or sets UpdatedDate
        /// </summary>
        DateTimeOffset UpdatedDate { get; set; }

        /// <summary>
        ///     override object.Equals method
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        bool Equals(object obj);

        /// <summary>
        ///     override object.GetHashCode method.
        /// </summary>
        /// <returns>Hash code</returns>
        int GetHashCode();
    }

    /// <summary>
    ///     An interface represent for an entity.
    /// </summary>
    public interface IEntity
    {
    }
}