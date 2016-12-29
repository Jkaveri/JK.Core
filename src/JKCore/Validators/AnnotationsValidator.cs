// Copyright (c) Ho Nguyen. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace JKCore.Validators
{
    #region

    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    using JKCore.Models;

    using ValidationResult = JKCore.Validators.Models.ValidationResult;

    #endregion

    /// <summary>
    /// </summary>
    public class AnnotationsValidator : ValidatorBase<object>
    {
        /// <summary>
        /// </summary>
        /// <param name="input">
        /// The input.
        /// </param>
        /// <returns>
        /// </returns>
        protected override ValidationResult Validating(object input)
        {
            var context = new ValidationContext(input, null, null);
            var validationResults = new List<System.ComponentModel.DataAnnotations.ValidationResult>();

            var isValid = Validator.TryValidateObject(input, context, validationResults, true);
            if (!isValid)
            {
                var failMessages =
                    validationResults.Select(
                        validationResult =>
                            new ErrorItem(
                                string.Format(validationResult.ErrorMessage, validationResult.MemberNames.First())));
                this.ValidationResult.Errors.AddRange(failMessages);
                return this.InValid();
            }

            return this.Valid();
        }
    }
}