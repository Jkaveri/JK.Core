// Copyright (c) Ho Nguyen. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace JKCore.Validators
{
    #region

    using System;

    using JKCore.Validators.Models;

    #endregion

    /// <summary>
    ///     The validator.
    /// </summary>
    /// <typeparam name="T">
    ///     Input type of validator.
    /// </typeparam>
    public abstract class ValidatorBase<T> : ValidatorBase
    {
        /// <summary>
        ///     Gets or sets the task result.
        /// </summary>
        public ValidationResult ValidationResult { get; set; }

        /// <summary>
        ///     The validate.
        /// </summary>
        /// <param name="input">
        ///     The input.
        /// </param>
        /// <returns>
        ///     The <see cref="Models.ValidationResult" />.
        /// </returns>
        public virtual ValidationResult Validate(T input)
        {
            this.ValidationResult = new ValidationResult(false);
            return this.Validating(input);
        }

        /// <summary>
        ///     The in valid.
        /// </summary>
        /// <param name="exception"></param>
        /// <returns>
        ///     The <see cref="Models.ValidationResult" />.
        /// </returns>
        protected virtual ValidationResult InValid(Exception exception)
        {
            this.ValidationResult.IsValid = false;

            return this.InValid(null, exception);
        }

        /// <summary>
        ///     The in valid.
        /// </summary>
        /// <param name="message">
        ///     The message.
        /// </param>
        /// <returns>
        ///     The <see cref="Models.ValidationResult" />.
        /// </returns>
        protected virtual ValidationResult InValid(string message)
        {
            return this.InValid(message, null);
        }

        /// <summary>
        ///     The in valid.
        /// </summary>
        /// <param name="message">
        ///     The message.
        /// </param>
        /// <param name="ex">
        ///     The ex.
        /// </param>
        /// <returns>
        ///     The <see cref="Models.ValidationResult" />.
        /// </returns>
        protected virtual ValidationResult InValid(string message, Exception ex)
        {
            this.ValidationResult.AddError(message, ex);
            return this.InValid();
        }

        /// <summary>
        ///     The in valid.
        /// </summary>
        /// <returns>
        ///     The <see cref="Models.ValidationResult" />.
        /// </returns>
        protected virtual ValidationResult InValid()
        {
            this.ValidationResult.IsValid = false;
            return this.ValidationResult;
        }

        /// <summary>
        ///     The valid.
        /// </summary>
        /// <returns>
        ///     The <see cref="Models.ValidationResult" />.
        /// </returns>
        protected virtual ValidationResult Valid()
        {
            this.ValidationResult.IsValid = true;
            this.ValidationResult.Errors.Clear();
            return this.ValidationResult;
        }

        /// <summary>
        ///     The validating.
        /// </summary>
        /// <param name="input">
        ///     The input.
        /// </param>
        /// <returns>
        ///     The <see cref="Models.ValidationResult" />.
        /// </returns>
        protected abstract ValidationResult Validating(T input);
    }

    /// <summary>
    /// </summary>
    public abstract class ValidatorBase
    {
    }
}