namespace JKCore.Test.Utilities
{
    #region

    using System;

    using FluentAssertions;

    using JKCore.Exceptions;
    using JKCore.Utilities;

    using Xunit;

    #endregion

    public class check_tests
    {
        [Fact]
        public void check_argument_not_null_should_not_throw_exception()
        {
            // Arrange
            object str = "";

            // Actions
            Action action = () => Check.ArgNotNull(str, nameof(str));

            // Assert
            action.ShouldNotThrow<Exception>();
        }

        [Fact]
        public void check_argument_not_null_should_throw_exception()
        {
            // Arrange
            object str = null;

            // Actions
            Action action = () => Check.ArgNotNull(str, nameof(str));

            // Assert
            action.ShouldThrow<ArgumentInvalidException>().And.Reason.Should().Be(InvalidReason.Null);
        }

        [Theory]
        [InlineData("1")]
        [InlineData(new[] { 1 })]
        [InlineData(1)]
        public void check_empty_should_not_throw_exception(object arg)
        {
            // Arrange 

            // Actions
            Action action = () => Check.ArgNotEmpty(arg, nameof(arg));

            // Assert
            action.ShouldNotThrow<ArgumentInvalidException>();
        }

        [Theory]
        [InlineData("")]
        [InlineData(new int[0])]
        public void check_empty_should_throw_exception(object arg)
        {
            // Arrange 

            // Actions
            Action action = () => Check.ArgNotEmpty(arg, nameof(arg));

            // Assert
            action.ShouldThrow<ArgumentInvalidException>().And.Reason.Should().Be(InvalidReason.Empty);
        }


        [Theory]
        [InlineData("", InvalidReason.Empty)]
        [InlineData(new int[0], InvalidReason.Empty)]
        [InlineData(null, InvalidReason.Null)]
        public void check_null_or_empty_should_throw_exception(object arg, InvalidReason expectedReason)
        {
            // Arrange 

            // Actions
            Action action = () => Check.ArgNotNullOrEmpty(arg, nameof(arg));

            // Assert
            action.ShouldThrow<ArgumentInvalidException>().And.Reason.Should().HaveFlag(expectedReason);
        }
    }
}