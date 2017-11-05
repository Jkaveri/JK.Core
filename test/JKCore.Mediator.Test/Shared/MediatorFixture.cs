#region

using System;
using JKCore.Mediator.Abstracts;
using JKCore.Mediator.Test.Handlers;
using Microsoft.Extensions.DependencyInjection;

#endregion

namespace JKCore.Mediator.Test.Shared
{
    public class MediatorFixture
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IServiceCollection _services;

        public MediatorFixture()
        {
            _services = new ServiceCollection();
            _services.AddScoped<ScopedService>();
            _services.AddMediator()
                .AddHandlersSameAssemblyWith<ExpectedHandler>();


            _serviceProvider = _services.BuildServiceProvider();
        }

        public IMediator Mediator => _serviceProvider.GetService<IMediator>();
        public IServiceProvider ServiceProvider => _serviceProvider;
    }
}