// Copyright (c) Ho Nguyen. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace JKCore.Modeling
{
    #region

    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    #endregion

    /// <summary>
    ///     Abstract Entity class with Key is <see cref="string" />
    /// </summary>
    public abstract class Entity : Entity<string>
    {
    }

    /// <summary>
    ///     abstract entity class which is identifiable
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1126:PrefixCallsCorrectly",
        Justification = "Reviewed. Suppression is OK here.")]
    public abstract class Entity<TKey> : IEntity<TKey>
    {
        private int? _hashCode;

        /// <summary>
        ///     Construct entity with id.
        /// </summary>
        /// <param name="id"></param>
        protected Entity(TKey id)
        {
            if (Equals(id, default(TKey)))
            {
                throw new ArgumentException($"The ID cannot be type's default: {default(TKey)}", nameof(id));
            }

            this.Id = id;
        }

        /// <summary>
        ///     Default constructor.
        /// </summary>
        protected Entity()
        {
        }

        /// <summary>
        ///     Gets or sets CreatedDate.
        /// </summary>
        public DateTimeOffset CreatedDate { get; set; }

        /// <summary>
        ///     Gets or sets Identity
        /// </summary>
        public TKey Id { get; set; }

        /// <summary>
        ///     Gets or sets UpdatedDate.
        /// </summary>
        public DateTimeOffset UpdatedDate { get; set; }

        /// <summary>Returns a value that indicates whether the values of two <see cref="T:JK.Core.Entity`1" /> objects are equal.</summary>
        /// <param name="left">The first value to compare.</param>
        /// <param name="right">The second value to compare.</param>
        /// <returns>
        ///     true if the <paramref name="left" /> and <paramref name="right" /> parameters have the same value; otherwise,
        ///     false.
        /// </returns>
        public static bool operator ==(Entity<TKey> left, Entity<TKey> right)
        {
            return Equals(left, right);
        }

        /// <summary>Returns a value that indicates whether two <see cref="T:JK.Core.Entity`1" /> objects have different values.</summary>
        /// <param name="left">The first value to compare.</param>
        /// <param name="right">The second value to compare.</param>
        /// <returns>true if <paramref name="left" /> and <paramref name="right" /> are not equal; otherwise, false.</returns>
        public static bool operator !=(Entity<TKey> left, Entity<TKey> right)
        {
            return !Equals(left, right);
        }

        /// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
        /// <returns>true if the current object is equal to the <paramref name="other" /> parameter; otherwise, false.</returns>
        /// <param name="other">An object to compare with this object.</param>
        public bool Equals(IEntity<TKey> other)
        {
            if (other == null)
            {
                return false;
            }

            if (Equals(this.Id, default(TKey)))
            {
                return ReferenceEquals(this, other);
            }

            return EqualityComparer<TKey>.Default.Equals(this.Id, other.Id);
        }

        /// <summary>Determines whether the specified object is equal to the current object.</summary>
        /// <returns>true if the specified object  is equal to the current object; otherwise, false.</returns>
        /// <param name="obj">The object to compare with the current object. </param>
        public override bool Equals(object obj)
        {
            var other = obj as IEntity<TKey>;
            return this.Equals(other);
        }

        /// <summary>Serves as the default hash function. </summary>
        /// <returns>A hash code for the current object.</returns>
        // ReSharper disable once NonReadonlyMemberInGetHashCode
        [SuppressMessage("ReSharper", "NonReadonlyMemberInGetHashCode", Justification = "Reviewed and it is ok")]
        public override int GetHashCode()
        {
            if (this._hashCode.HasValue)
            {
                return this._hashCode.Value;
            }

            var isTransient = Equals(this.Id, default(TKey));
            if (isTransient)
            {
                this._hashCode = base.GetHashCode();
                return this._hashCode.Value;
            }

            this._hashCode = this.Id.GetHashCode();
            return this._hashCode.Value;
        }
    }
}