namespace JKCore.Test.Utilities
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    using FluentAssertions;

    using JKCore.Utilities;

    using Xunit;

    public class ReflectionUtilsTest
    {
        [Fact]
        public void can_serialize_object_to_keyvalue_pair_collection()
        {
            // Arrange

            var data = new
            {
                Field1 = 123,
                Field2 = "123"
            };

            var type = data.GetType();
            var properties = type.GetProperties()
                .ToDictionary(k => k.Name, 
                x => x.GetGetMethod().Invoke(data, null) == null ? "" 
                    : x.GetGetMethod().Invoke(data, null).ToString());

            // Actions
            IEnumerable<KeyValuePair<string, string>> result = ReflectionUtils.ObjectToKeyValuePairs(data);

            // Assertions
            result.Should().NotBeNullOrEmpty();

            foreach (var item in result)
            {
                properties.Should().ContainKey(item.Key);
                properties[item.Key].Should().NotBeNull();
            }
        }
    }
}
