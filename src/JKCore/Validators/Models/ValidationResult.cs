// Copyright (c) Ho Nguyen. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace JKCore.Validators.Models
{
    #region

    using System;
    using System.Collections.Generic;
    using System.Linq;

    using JKCore.Exceptions.Validation;
    using JKCore.Models;

    #endregion

    /// <summary>
    ///     The validation result.
    /// </summary>
    public class ValidationResult : ErroritemContainer
    {
        private bool _isValid;

        /// <summary>
        ///     Construct validation result with isValid state.
        /// </summary>
        /// <param name="isValid">True if you want to construct valid validation result.</param>
        public ValidationResult(bool isValid)
        {
            this.IsValid = isValid;
        }

        /// <summary>
        ///     True if validation result is valid.
        /// </summary>
        public bool IsValid
        {
            get
            {
                return this._isValid && this.Errors.Count == 0;
            }

            set
            {
                this._isValid = value;
            }
        }

        /// <summary>
        ///     Throws the exception if not valid.
        ///     When  the <see cref="ErroritemContainer.Errors" /> property is not exception. We pick the first on exception object in
        ///     <see cref="ErroritemContainer.Errors" /> as a inner exception.
        /// </summary>
        /// <exception cref="ValidationException"></exception>
        public void ThrowExceptionIfNotValid()
        {
            if (!this.IsValid)
            {
                var firstException =
                    this.Errors.Where(t => t.Exception != null).Select(t => t.Exception).FirstOrDefault();

                throw new ValidationException(this.ToString(), firstException);
            }
        }

        /// <summary>
        ///     Throws the exception if not valid.
        /// </summary>
        /// <typeparam name="TException">The type of the exception.</typeparam>
        /// <param name="args">The arguments to build exception. <typeparamref name="TException" /></param>
        /// <exception cref="ValidationException">
        /// </exception>
        public void ThrowExceptionIfNotValid<TException>() where TException : Exception
        {
            if (this.IsValid)
            {
                return;
            }

            throw  (TException) Activator.CreateInstance(typeof(TException), ToString());
        }

        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
        {
            if (this.Errors.Count > 0)
            {
                return string.Join("\n", this.Errors.Select(e => e.Message));
            }

            return "Valid";
        }
    }
}