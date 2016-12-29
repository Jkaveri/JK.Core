using FluentAssertions;
using JKCore.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace JKCore.Test.Utilities
{
    public class ReadableFormatterTest
    {
        [Fact]
        public void get_full_address_should_not_return_empty()
        {
            // Arrange
            var address = "354 pham ngu lao";
            var expected = "354 pham ngu lao";

            // Actions
            var fullAddress = ReadableFormatter.GetFullAddress(address);

            // Assertion
            fullAddress.Should().NotBeNullOrEmpty();
            fullAddress.Should().Be(expected);
        }
    }
}
