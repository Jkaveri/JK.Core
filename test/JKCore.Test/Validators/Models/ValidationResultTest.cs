namespace JKCore.Test.Validators.Models
{
    #region

    using System;

    using FluentAssertions;

    using JKCore.Exceptions.Validation;
    using JKCore.Validators.Models;

    using Xunit;

    #endregion

    /// <summary>
    /// </summary>
    public class ValidationResultTest
    {
        /// <summary>
        /// </summary>
        [Fact]
        public void can_add_error_exception()
        {
            // Arrange
            var result = new ValidationResult(false);
            var expected = new Exception("fakeMessage");

            // Actions
            result.AddError(expected);

            // Assertions.
            result.IsValid.Should().BeFalse();
            result.Errors.Should().NotBeEmpty();
            result.Errors[0].Exception.Should().Be(expected);
            result.Errors[0].Message.Should().BeNull();
        }

        /// <summary>
        /// </summary>
        [Fact]
        public void can_add_error_message()
        {
            // Arrange
            var result = new ValidationResult(false);
            var expected = "fakeMessage";

            // Actions
            result.AddError(expected);

            // Assertions.
            result.IsValid.Should().BeFalse();
            result.Errors.Should().NotBeEmpty();
            result.Errors[0].Message.Should().Be(expected);
            result.Errors[0].Exception.Should().BeNull();
        }

        /// <summary>
        /// </summary>
        [Fact]
        public void can_add_error_message_and_exception()
        {
            // Arrange
            var result = new ValidationResult(false);
            var message = "fake message";
            var exception = new Exception(message);

            // Actions
            result.AddError(message, exception);

            // Assertions.
            result.IsValid.Should().BeFalse();
            result.Errors.Should().NotBeEmpty();
            result.Errors[0].Exception.Should().Be(exception);
            result.Errors[0].Message.Should().Be(message);
        }

        /// <summary>
        /// </summary>
        [Fact]
        public void can_build_valid_result()
        {
            // Arrange
            var result = new ValidationResult(true);

            // Actions

            // Assertions.
            result.IsValid.Should().BeTrue();
            result.Errors.Should().BeEmpty();
        }

        /// <summary>
        /// </summary>
        [Fact]
        public void should_auto_invalid_when_add_an_error()
        {
            // Arrange
            var result = new ValidationResult(true);
            var message = "fake message";
            var exception = new Exception(message);

            // Actions
            result.AddError(message, exception);

            // Assertions.
            result.IsValid.Should().BeFalse("Because we have an error");
            result.Errors.Should().NotBeEmpty();
            result.Errors[0].Exception.Should().Be(exception);
            result.Errors[0].Message.Should().Be(message);
        }

        /// <summary>
        /// </summary>
        [Fact]
        public void should_throw_error_if_needed()
        {
            // Arranges
            var result = new ValidationResult(false);
            var message = "fake message";
            var exception = new InvalidOperationException(message);
            result.AddError(message, exception);

            // Actions and Assertions
            var ex = Assert.Throws<ValidationException>(() => result.ThrowExceptionIfNotValid());

            ex.Message.Contains(message).Should().BeTrue();
        }
    }
}