namespace JKCore.Test.Utilities
{
    #region

    using System.Linq;
    using System.Reflection;

    using FluentAssertions;

    using JKCore.Utilities;
    using JKCore.Validators;

    using Xunit;

    #endregion

    public class reflection_utils_test
    {
        [Fact]
        public void can_serialize_object_to_keyvalue_pair_collection()
        {
            // Arrange

            var data = new { Field1 = 123, Field2 = "123" };

            var type = data.GetType();
            var properties = type.GetProperties()
                .ToDictionary(
                    k => k.Name,
                    x =>
                        x.GetGetMethod().Invoke(data, null) == null
                            ? ""
                            : x.GetGetMethod().Invoke(data, null).ToString());

            // Actions
            var result = ReflectionUtils.ObjectToKeyValuePairs(data);

            // Assertions
            result.Should().NotBeNullOrEmpty();

            foreach (var item in result)
            {
                properties.Should().ContainKey(item.Key);
                properties[item.Key].Should().NotBeNull();
            }
        }

        [Fact]
        public void return_all_types_in_assembly()
        {
            // Arrange

            // Actions.
            var types = ReflectionUtils.AllTypesInAssemblyOf<AnnotationsValidator>().ToList();

            // Assertions.
            types.Should().NotBeNullOrEmpty();
            types.Should().Contain(typeof(AnnotationsValidator));
        }

        [Fact]
        public void return_all_types_in_assembly2()
        {
            // Arrange

            // Actions.
            var types = ReflectionUtils.AllTypesInAssemblyOf(typeof(AnnotationsValidator)).ToList();

            // Assertions.
            types.Should().NotBeNullOrEmpty();
            types.Should().Contain(typeof(AnnotationsValidator));
        }

        [Fact]
        public void return_type_selector_when_scan()
        {
            var selector = TypeCollector.Scan(typeof(AnnotationsValidator));

            // Assertions
            selector.Should().NotBeNull();
            selector.Types.Any().Should().BeTrue();
        }
    }
}