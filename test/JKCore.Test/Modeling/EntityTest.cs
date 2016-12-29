using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JKCore.Test.Modeling
{
    using FluentAssertions;

    using JKCore.Modeling;

    using Xunit;

    public class EntityTest
    {
        private class FakeEntity : Entity<Guid>
        {
            
        }

        [Fact]
        public void should_return_same_hash_code()
        {
            // Arranges
            var entity =  new FakeEntity(); 
            int expectedHashCode = entity.GetHashCode();

            // Actions
            entity.Id = Guid.NewGuid();
            int hashCode = entity.GetHashCode();
            
            // Assertions
            hashCode.Should().Be(expectedHashCode);
        }

        [Fact]
        public void should_return_different_hash_code()
        {
            // Arranges.
            var entity1 = new FakeEntity();
            var entity2 = new FakeEntity();

            // Actions.
            var hashCode1 = entity1.GetHashCode();
            var hashCode2 = entity2.GetHashCode();

            // Assertions.
            hashCode1.Should().NotBe(hashCode2);
        }


        [Fact]
        public void should_not_equals()
        {
            // Arranges.
            var entity1 = new FakeEntity();
            var entity2 = new FakeEntity();

            // Actions.
            var equal = entity1.Equals(entity2);

            // Assertions.
            equal.Should().BeFalse();
        }

        [Fact]
        public void should_equals()
        {
            // Arranges.
            var entity1 = new FakeEntity();
            var entity2 = new FakeEntity();
            var guid = Guid.NewGuid(); 
            
            // Actions.
            entity1.Id = guid;
            entity2.Id = guid;
            var equal = entity1.Equals(entity2);

            // Assertions.
            equal.Should().BeTrue();
            (entity1 == entity2).Should().BeTrue();
        }
    }
}
