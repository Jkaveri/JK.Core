using FluentAssertions;
using JKCore.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace JKCore.Test.Utilities
{
    public class CollectionUtilsTest
    {
        private enum TestEnum
        {
            Item1,
            Item2
        }
        [Fact]
        public void should_return_collection_of_enum_type()
        {
            // Arrange
            Func<TestEnum, string> selector = (item) =>
            {
                return Enum.GetName(typeof(TestEnum), item);
            };
            // Actions
            var collection = CollectionUtils.GetEnumCollection<TestEnum>().Select(selector).ToList();

            // Assertions
            collection.Should().NotBeEmpty();
            collection.Should().Contain(nameof(TestEnum.Item1));
            collection.Should().Contain(nameof(TestEnum.Item2));
        }
    }
}
