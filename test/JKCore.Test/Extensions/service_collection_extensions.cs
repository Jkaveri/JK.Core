namespace JKCore.Test.Extensions
{
    #region

    using FluentAssertions;

    using JKCore.Extensions;
    using JKCore.Test.Fake.Classes;
    using JKCore.Validators;

    using Microsoft.Extensions.DependencyInjection;

    using Xunit;

    #endregion

    public class service_collection_extensions
    {
        [Fact]
        public void scan_assembly_and_register_by_abstract()
        {
            // Arranges 
            IServiceCollection services = new ServiceCollection();

            // Actions.
            services.Scan<AAbstractClass>(collector => { collector.ImplementationOf<AAbstractClass>(); })
                .ByAbstractClasses();

            var serviceProvider = services.BuildServiceProvider();
            var service = serviceProvider.GetService<AAbstractClass>();
            var childServices = serviceProvider.GetServices<AAbstractClass>();

            // Assertions
            service.Should().NotBeNull();
            childServices.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public void scan_assembly_and_register_by_it_self()
        {
            // Arranges  
            IServiceCollection services = new ServiceCollection();

            // Actions.
            services.Scan<AClass>().ByItSelf();

            var serviceProvider = services.BuildServiceProvider();
            var service = serviceProvider.GetService<AClass>();

            // Assertions
            service.Should().NotBeNull();
        }

        [Fact]
        public void scan_assembly_with_type_collector_filter()
        {
            // Arranges 
            IServiceCollection services = new ServiceCollection();

            // Actions.
            services.Scan<AClass>(collector => { collector.Ignore<AClass>(); }).ByItSelf();

            var serviceProvider = services.BuildServiceProvider();
            var service = serviceProvider.GetService<AClass>();

            // Assertions
            service.Should().BeNull();
        }

    }
}