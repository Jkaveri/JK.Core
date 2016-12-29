namespace JKCore.Test.Validators
{
    #region

    using FluentAssertions;

    using JKCore.Test.Fake.Models;
    using JKCore.Validators;

    using Xunit;

    #endregion

    public class DataAnnotationsValidatorTest
    {
        [Fact]
        public void should_return_invalid()
        {
            // Arrange
            var fakeModel = new ModelWithAnnotations();
            var validator = new AnnotationsValidator();

            // Actions
            var result = validator.Validate(fakeModel);

            // Assertions
            result.IsValid.Should().BeFalse();
            result.Errors.Should().NotBeEmpty();
        }

        [Fact]
        public void should_return_invalid_with_validator_manager()
        {
            //// Arrange
            //using (var setup = new TestQuickSetup())
            //{
            //    var fakeModel = new ModelWithAnnotations();
            //    var validator = setup.Container.Resolve<AnnotationsValidator>();

            //    // Actions
            //    var result = validator.Validate(fakeModel);

            //    // Assertions
            //    result.IsValid.Should().BeFalse();
            //    result.Errors.Should().NotBeEmpty();
            //}
        }
    }
}