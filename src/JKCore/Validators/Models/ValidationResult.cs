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
    public class ValidationResult
    {
        private bool _isValid;

        /// <summary>
        ///     Construct validation result with isValid state.
        /// </summary>
        /// <param name="isValid">True if you want to construct valid validation result.</param>
        public ValidationResult(bool isValid)
        {
            this.IsValid = isValid;
            this.Errors = new List<ErrorItem>();
        }

        /// <summary>
        ///     gets errors.
        /// </summary>
        public virtual List<ErrorItem> Errors { get; }

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
        ///     The add error.
        /// </summary>
        /// <param name="msg">
        ///     The error message.
        /// </param>
        public void AddError(string msg)
        {
            if (string.IsNullOrEmpty(msg))
            {
                return;
            }

            this.Errors.Add(new ErrorItem(msg));
        }

        /// <summary>
        ///     Add an error item with an exception.
        /// </summary>
        /// <param name="exception"></param>
        public void AddError(Exception exception)
        {
            if (exception == null)
            {
                return;
            }

            this.Errors.Add(new ErrorItem(exception));
        }

        /// <summary>
        ///     The add error item with message and exception.
        /// </summary>
        /// <param name="msg">
        ///     The error message.
        /// </param>
        /// <param name="ex">
        ///     The ex.
        /// </param>
        public void AddError(string msg, Exception ex)
        {
            this.Errors.Add(new ErrorItem(msg, ex));
        }

        /// <summary>
        ///     The add errors.
        /// </summary>
        /// <param name="errors">
        ///     The errors.
        /// </param>
        public void AddErrors(IEnumerable<ErrorItem> errors)
        {
            if (errors != null)
            {
                this.Errors.AddRange(errors);
            }
        }

        /// <summary>
        ///     Throws the exception if not valid.
        ///     When  the <see cref="Errors" /> property is not exception. We pick the first on exception object in
        ///     <see cref="Errors" /> as a inner exception.
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
        public void ThrowExceptionIfNotValid<TException>(params object[] args) where TException : Exception
        {
            if (this.IsValid)
            {
                return;
            }

            var msg = this.ToString();
            if (args != null)
            {
                var innerException = (TException)Activator.CreateInstance(typeof(TException), args);
                throw new ValidationException(msg, innerException);
            }

            throw new ValidationException(msg, Activator.CreateInstance<TException>());
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