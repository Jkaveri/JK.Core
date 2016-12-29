namespace MyDoctor.Core.Test.Fake.Validators
{
    using JKCore.Validators;
    using JKCore.Validators.Models;

    public class FakeValidValidator : ValidatorBase<object>
    {

        /// <summary>
        ///     The validating.
        /// </summary>
        /// <param name="input">
        ///     The input.
        /// </param>
        /// <returns>
        ///     The <see cref="mHelpdesk.Core.Services.Validation.ValidationResult" />.
        /// </returns>
        protected override ValidationResult Validating(object input)
        {
            return this.Valid();
        }
    }
}
