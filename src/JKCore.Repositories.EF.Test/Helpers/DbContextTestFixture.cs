
namespace JKCore.Repositories.EF.Test.Helpers
{
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.EntityFrameworkCore;
    using JKCore.Repositories.EF.Test.Data;

    public class DbContextTestFixture
    {
        private readonly IServiceCollection _services;
        private readonly IServiceProvider _serviceProvider;

        public DbContextTestFixture()
        {
            _services = new ServiceCollection();
            _services
                .AddEntityFrameworkInMemoryDatabase()
                .AddDbContext<TestDbContext>(opts => opts.UseInMemoryDatabase());

            _serviceProvider = _services.BuildServiceProvider();
        }

        protected TestDbContext CreateDbContext()
        {
            var builder = new DbContextOptionsBuilder();
            builder.UseInMemoryDatabase();

            return new TestDbContext(builder.Options);
        }

    }
}
