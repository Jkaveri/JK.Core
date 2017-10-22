// Copyright (c) Ho Nguyen. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace JKCore.Validators
{
    #region

    using System;
    using System.Collections.Generic;

    using JKCore.Models;
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
        /// <param name="exception">
        ///     The exception.
        /// </param>
        /// <returns>
        ///     The <see cref="Models.ValidationResult" />.
        /// </returns>
        protected virtual ValidationResult InValid(string message, Exception exception)
        {
            var result = this.InValid();

            result.AddError(message, exception);
            return result;
        }

        /// <summary>
        /// </summary>
        /// <param name="errors">
        /// The errors.
        /// </param>
        /// <returns>
        /// </returns>
        protected virtual ValidationResult InValid(IEnumerable<ErrorItem> errors)
        {
            var result = this.InValid();
            result.AddErrors(errors);
            return result;
        }

        /// <summary>
        ///     The in valid.
        /// </summary>
        /// <returns>
        ///     The <see cref="Models.ValidationResult" />.
        /// </returns>
        protected virtual ValidationResult InValid()
        {
            return new ValidationResult(false);
        }

        /// <summary>
        ///     The valid.
        /// </summary>
        /// <returns>
        ///     The <see cref="Models.ValidationResult" />.
        /// </returns>
        protected virtual ValidationResult Valid()
        {
            return new ValidationResult(true);
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