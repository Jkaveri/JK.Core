using FluentAssertions;
using JKCore.Test.Fake;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace JKCore.Test
{
    public class ValueObjectTest
    {
        [Theory()]
        [InlineData("string", 1, "2017-05-01", false)]
        [InlineData("", 0, null, true)]
        public void equals_should_return_true(string str, int number, DateTime datetime, bool boolean)
        {
            // arrange
            var obj1 = new FakeValueObject
            {
                StringValue = str,
                IntValue = number,
                DateTimeValue = datetime,
                BooleanValue = boolean
            };

            var obj2 = new FakeValueObject
            {
                StringValue = str,
                IntValue = number,
                DateTimeValue = datetime,
                BooleanValue = boolean
            };

            // Actions
            var result = obj1.Equals(obj2);
            var result2 = obj2.Equals(obj1);

            // Assertion
            result.Should().BeTrue();
            result2.Should().BeTrue();
        }

        [Theory()]
        [InlineData("string", 1, "2017-05-01", false)]
        public void equals_operator_should_return_true(string str, int number, DateTime datetime, bool boolean)
        {
            // arrange
            var obj1 = new FakeValueObject
            {
                StringValue = str,
                IntValue = number,
                DateTimeValue = datetime,
                BooleanValue = boolean
            };

            var obj2 = new FakeValueObject
            {
                StringValue = str,
                IntValue = number,
                DateTimeValue = datetime,
                BooleanValue = boolean
            };

            // Actions
            var result = obj1 == obj2;
            var result2 = obj2 == obj1;

            // Assertion
            result.Should().BeTrue();
            result2.Should().BeTrue();
        }


        [Theory()]
        [InlineData("string", 1, "2017-05-01", false)]
        public void GetHashCode_should_return_same(string str, int number, DateTime datetime, bool boolean)
        {
            // arrange
            var obj1 = new FakeValueObject
            {
                StringValue = str,
                IntValue = number,
                DateTimeValue = datetime,
                BooleanValue = boolean
            };

            var obj2 = new FakeValueObject
            {
                StringValue = str,
                IntValue = number,
                DateTimeValue = datetime,
                BooleanValue = boolean
            };

            // Actions
            var hash1 = obj1.GetHashCode();
            var hash2 = obj2.GetHashCode();

            // Assertion
            hash1.Should().Be(hash2);
        }



    }
}
