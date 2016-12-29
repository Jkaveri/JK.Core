// Copyright (c) Ho Nguyen. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace JKCore.Modeling
{
    #region

    using System;
    using System.Linq;
    using System.Reflection;

    #endregion

    /// <summary>
    ///     Abstract class for ValueObject in DDD
    ///     <seealso
    ///         url="https://blogs.msdn.microsoft.com/cesardelatorre/2011/06/06/implementing-a-value-object-base-class-supertype-patternddd-patterns-related/" />
    /// </summary>
    /// <typeparam name="TValueObject">A value object class</typeparam>
    public abstract class ValueObject<TValueObject> : IEquatable<ValueObject<TValueObject>>
        where TValueObject : ValueObject<TValueObject>
    {
        /// <summary>
        ///     Override == operation
        /// </summary>
        /// <param name="x">
        ///     <typeparamref name="TValueObject" />
        /// </param>
        /// <param name="y">
        ///     <typeparamref name="TValueObject" />
        /// </param>
        /// <returns>
        ///     <see cref="bool" />
        /// </returns>
        public static bool operator ==(ValueObject<TValueObject> x, ValueObject<TValueObject> y)
        {
            // If both are null, or both are same instance, return true.
            if (ReferenceEquals(x, y))
            {
                return true;
            }

            // If one is null, but not both, return false.
            if ((object)x == null || (object)y == null)
            {
                return false;
            }

            // Return true if the fields match:
            return x.Equals(y);
        }

        /// <summary>
        ///     Override != operation
        /// </summary>
        /// <param name="x">
        ///     <typeparamref name="TValueObject" />
        /// </param>
        /// <param name="y">
        ///     <typeparamref name="TValueObject" />
        /// </param>
        /// <returns>
        ///     <see cref="bool" />
        /// </returns>
        public static bool operator !=(ValueObject<TValueObject> x, ValueObject<TValueObject> y)
        {
            return !(x == y);
        }

        /// <summary>
        ///     Override object.Equals
        /// </summary>
        /// <param name="other">A <typeparamref name="TValueObject" /></param>
        /// <returns>
        ///     <see cref="bool" />
        /// </returns>
        public bool Equals(ValueObject<TValueObject> other)
        {
            if (Equals(other, null))
            {
                return false;
            }

            // compare all public properties
            var publicProperties = this.GetType().GetProperties();

            if (publicProperties != null && publicProperties.Any())
            {
                var result = true;
                foreach (var item in publicProperties)
                {
                    // compare two values using default equatable method
                    if (!item.GetValue(this, null).Equals(item.GetValue(other, null)))
                    {
                        result = false;
                        break;
                    }
                }

                return result;
            }

            return true;
        }

        /// <summary>
        ///     override object.Equals
        /// </summary>
        /// <param name="obj">A comparison object</param>
        /// <returns>A <see cref="bool" /> value</returns>
        public override bool Equals(object obj)
        {
            if (Equals(obj, null))
            {
                return false;
            }

            var item = obj as ValueObject<TValueObject>;

            return this.Equals(item);
        }

        /// <summary>
        ///     override object.GetHashCode
        /// </summary>
        /// <returns>Hash code of object</returns>
        public override int GetHashCode()
        {
            var hashCode = 31;
            var changeMultiplier = false;
            var index = 1;

            // compare all public properties
            var publicProperties = this.GetType().GetProperties();

            if (publicProperties != null && publicProperties.Any())
            {
                foreach (var item in publicProperties)
                {
                    var value = item.GetValue(this, null);

                    if (value != null)
                    {
                        hashCode = hashCode * (changeMultiplier ? 59 : 114) + value.GetHashCode();

                        changeMultiplier = !changeMultiplier;
                    }
                    else
                    {
                        hashCode = hashCode ^ (index * 13);

                        // only for support {"a",null,null,"a"} <> {null,"a","a",null}
                    }
                }
            }

            return hashCode;
        }
    }
}