namespace JKCore.Test.Utilities
{
    #region

    using System;
    using System.Linq;

    using FluentAssertions;

    using JKCore.Utilities;
    using JKCore.Validators;

    using Xunit;

    #endregion

    public class type_selector_test
    {
        private interface IAmInterface
        {
        }

        [Theory]
        [InlineData(new[] { typeof(AnnotationsValidator), typeof(Check) }, typeof(AnnotationsValidator))]
        [InlineData(new[] { typeof(AnnotationsValidator), typeof(DateTime) }, typeof(DateTime))]
        [InlineData(new[] { typeof(AnnotationsValidator), typeof(bool) }, typeof(bool))]
        public void ignore_a_type(Type[] types, Type type)
        {
            // Arrange
            // Actions
            var selector = TypeCollector.Create(types);
            var result = selector.Ignore(type).ToList();

            // Assertions
            result.Should().NotBeNull();
            result.Should().NotContain(type);
        }

        [Fact]
        public void ignore_static_classes()
        {
            // Arrange
            var staticClass = typeof(StaticClass);
            var abstractClass = typeof(AbstractClass);
            var normalClass = typeof(AnnotationsValidator);
            var structType = typeof(DateTime);

            var collection = new[] { staticClass, abstractClass, normalClass, structType };

            // Actions
            var selector = TypeCollector.Create(collection);
            var result = selector.IgnoreStaticClasses().ToList();

            // Assertions
            result.Should().NotBeNull();
            result.Should().NotContain(staticClass);
            result.Should().Contain(abstractClass);
            result.Should().Contain(normalClass);
            result.Should().Contain(structType);
        }

        [Fact]
        public void select_implement_of_type()
        {
            // Arrange
            var types = new[]
                            {
                               typeof(NormalClass), typeof(AbstractClass), typeof(DateTime), typeof(ImplementInterface) 
                            };
            var selector = TypeCollector.Create(types);
            // Actions
            var result = selector.ImplementationOf(typeof(IAmInterface)).ToList();

            // Assertions.
            result.Should().NotBeNullOrEmpty();
            result.Should().Contain(typeof(ImplementInterface));
            result.Should().NotContain(typeof(NormalClass));
            result.Should().NotContain(typeof(AbstractClass));
            result.Should().NotContain(typeof(DateTime));
        }

        [Fact]
        public void select_implement_of_type2()
        {
            // Arrange
            var types = new[]
                            {
                               typeof(NormalClass), typeof(AbstractClass), typeof(DateTime), typeof(ImplementInterface), 2.GetType()
                            };
            var selector = TypeCollector.Create(types);
            // Actions
            var result = selector.ImplementationOf<IAmInterface>().ToList();

            // Assertions.
            result.Should().NotBeNullOrEmpty();
            result.Should().Contain(typeof(ImplementInterface));
            result.Should().NotContain(typeof(NormalClass));
            result.Should().NotContain(typeof(AbstractClass));
            result.Should().NotContain(typeof(DateTime));
        }

        [Fact]
        public void select_all_classes()
        {
            // Arrange

            var normalClass = typeof(NormalClass);
            var abstractClass = typeof(AbstractClass);
            var structType = typeof(DateTime);
            var interaceType = typeof(IAmInterface);
            var types = new[]
                            {
                              normalClass, abstractClass, structType,  interaceType
                            };
            var selector = TypeCollector.Create(types);
            // Actions
            var result = selector.AllClasses().ToList();

            // Assertions.
            result.Should().NotBeNullOrEmpty();
            result.Should().Contain(normalClass);
            result.Should().Contain(abstractClass);     
            result.Should().NotContain(interaceType);
            result.Should().NotContain(structType);
        }

        private static class StaticClass
        {
        }

        private abstract class AbstractClass
        {
        }

        private class ImplementInterface : IAmInterface
        {
        }

        private class NormalClass
        {
        }
    }
}