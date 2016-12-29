namespace MyDoctor.Core.Test.Fake.Validators
{
    using JKCore.Validators;
    using JKCore.Validators.Models;
    using System;

    public class FakeInvalidValidator : ValidatorBase<object>
    {
        public enum InvalidMode
        {
            JustInvalid,
            InvalidWithMessage,
            InvalidWithException,
            InvalidWithMessageAndException
        }

        public string Message { get; set; }
        public Exception Exception { get; set; }
        public InvalidMode Mode { get; set; }

        public FakeInvalidValidator()
        {
            this.Mode = InvalidMode.JustInvalid;
        }
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
            switch (this.Mode)
            {
                case InvalidMode.InvalidWithMessage:
                    return this.InValid(this.Message);
                case InvalidMode.InvalidWithException:
                    return this.InValid(this.Exception);
                case InvalidMode.InvalidWithMessageAndException:
                    return this.InValid(this.Message, this.Exception);
                default:
                    break;
            }

            return this.InValid();
        }
    }
}