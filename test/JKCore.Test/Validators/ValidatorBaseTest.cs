
namespace JKCore.Test.Validators
{
    using FluentAssertions;
    using MyDoctor.Core.Test.Fake.Validators;
    using System;
    using Xunit;

    public class ValidatorBaseTest
    {
        [Fact]
        public void can_return_valid()
        {
            // Arrange
            var fakeValidValidator = new FakeValidValidator();

            // Actions.
            var result = fakeValidValidator.Validate("123456");

            // Assertion
            result.Should().NotBeNull();
            result.Should().Be(fakeValidValidator.ValidationResult);
            result.IsValid.Should().BeTrue();
            result.Errors.Should().BeEmpty();
        }

        [Fact]
        public void can_return_invalid()
        {
            // Arrange
            var fakeInvalidValidator = new FakeInvalidValidator();

            // Actions
            var result = fakeInvalidValidator.Validate("1234567");

            // Assertions.
            result.Should().Be(fakeInvalidValidator.ValidationResult);
            result.IsValid.Should().BeFalse();
            result.Errors.Should().BeEmpty();
        }

        [Fact]
        public void can_return_invalid_with_message()
        {
            // Arrange
            var fakeInvalidValidator = new FakeInvalidValidator
            {
                Message = "fake_message",
                Mode =
                                                   FakeInvalidValidator.InvalidMode
                                                   .InvalidWithMessage
            };
            // Actions
            var result = fakeInvalidValidator.Validate("1234567");

            // Assertions.
            result.Should().Be(fakeInvalidValidator.ValidationResult);
            result.IsValid.Should().BeFalse();
            result.Errors.Should().NotBeEmpty();
            result.Errors[0].Message.Should().Be(fakeInvalidValidator.Message);
        }

        [Fact]
        public void can_return_invalid_with_exception()
        {
            // Arrange
            var fakeInvalidValidator = new FakeInvalidValidator
            {
                Exception = new Exception("fake_message"),
                Mode =
                                                   FakeInvalidValidator.InvalidMode
                                                   .InvalidWithException
            };

            // Actions
            var result = fakeInvalidValidator.Validate("1234567");

            // Assertions.
            result.Should().Be(fakeInvalidValidator.ValidationResult);
            result.IsValid.Should().BeFalse();
            result.Errors.Should().NotBeEmpty();
            result.Errors[0].Exception.Should().Be(fakeInvalidValidator.Exception);
        }

        [Fact]
        public void can_return_invalid_with_message_and_exception()
        {
            // Arrange
            var fakeInvalidValidator = new FakeInvalidValidator
            {
                Exception = new Exception("fake_message"),
                Message = "fake_message",
                Mode =
                                                   FakeInvalidValidator.InvalidMode
                                                   .InvalidWithMessageAndException
            };
            // Actions
            var result = fakeInvalidValidator.Validate("1234567");

            // Assertions.
            result.Should().Be(fakeInvalidValidator.ValidationResult);
            result.IsValid.Should().BeFalse();
            result.Errors.Should().NotBeEmpty();
            result.Errors[0].Exception.Should().Be(fakeInvalidValidator.Exception);
            result.Errors[0].Message.Should().Be(fakeInvalidValidator.Message);
        }
    }
}
