namespace JKCore.Test
{
    #region

    using System;

    using FluentAssertions;

    using JKCore.Modeling;
    using JKCore.Test.Fake;

    using Moq;

    using Xunit;

    #endregion

    public class EntityTest
    {
        [Fact]
        public void entities_should_equal_by_id()
        {
            // Arrange
            var id = Guid.NewGuid();
            var entity1 = new FakeEntity(id);
            var entity2 = new FakeEntity(id);

            // Assertion
            entity1.Equals(entity2).Should().BeTrue();
        }

        [Fact]
        public void entity_equal_null_should_return_false()
        {
            // Arrange
            var id = Guid.NewGuid();
            var entity1 = new FakeEntity(id);

            // Assertion
            entity1.Equals(null).Should().BeFalse();
        }

        [Fact]
        public void entity_should_have_fields()
        {
            // Arrange
            var mock = new Mock<Entity>();

            // Actions
            var entity = mock.Object;

            // Assertion
            entity.Id.Should().BeNullOrEmpty();
            entity.CreatedDate.Should().Be(default(DateTimeOffset));
            entity.UpdatedDate.Should().Be(default(DateTimeOffset));
        }

        [Fact]
        public void entity_string_should_have_fields()
        {
            // Arrange
            var mock = new Mock<Entity<string>>();

            // Actions
            var entity = mock.Object;

            // Assertion
            entity.Id.Should().Be(default(string));
            entity.CreatedDate.Should().Be(default(DateTimeOffset));
            entity.UpdatedDate.Should().Be(default(DateTimeOffset));
        }
    }
}