namespace JKCore.Mediator.Test.Shared
{
    using System;

    using Microsoft.Extensions.DependencyInjection;
    using JKCore.Mediator.Test.CommandHandlers;

    public class MediatorFixture
    {
        private readonly IServiceCollection _services;

        private readonly IServiceProvider _serviceProvider;

        public MediatorFixture()
        { 
            this._services = new ServiceCollection();
            this._services.AddMediator().AddMediatorTypesInAssemblyOf<ExpectedResultAsyncCommandHandler>();
            this._serviceProvider = this._services.BuildServiceProvider();
        }

        public IMediator Mediator => this._serviceProvider.GetService<IMediator>();
    }
}