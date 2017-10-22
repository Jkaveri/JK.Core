#region

using System;
using System.Linq;
using System.Reflection;
using JKCore.Mediator.Abstracts;
using Microsoft.Extensions.DependencyInjection;
using static JKCore.Utilities.ReflectionUtils;

#endregion

namespace JKCore.Mediator
{
    public class MediatorServicesBuilder
    {
        private readonly IServiceCollection _services;

        public MediatorServicesBuilder(IServiceCollection services)
        {
            _services = services;
        }

        public MediatorServicesBuilder AddFilter<TFilter>() where TFilter : MediatorFilter
        {
            _services.AddTransient<MediatorFilter, TFilter>();
            return this;
        }

        public MediatorServicesBuilder AddFilter<TFilter>(Func<IServiceProvider, TFilter> factory) where TFilter : MediatorFilter
        {
            _services.AddTransient<MediatorFilter, TFilter>(factory);
            return this;
        }

        public MediatorServicesBuilder AddHandlersSameAssemblyWith<T>()
        {
            return AddHandlers(GetAssembly(typeof(T)));
        }

        public MediatorServicesBuilder AddHandlers(Assembly assembly)
        {
            var result = assembly.GetTypes().Where(type => IsAssignAbleTo(type, typeof(IMediatorHandler)));

            foreach (var type in result)
            {
                // Add it selft
                _services.Add(new ServiceDescriptor(type, type, ServiceLifetime.Transient));

                // Implemented interface
                foreach (var @interface in type.GetTypeInfo().ImplementedInterfaces)
                {
                    var descriptor = new ServiceDescriptor(@interface, type, ServiceLifetime.Transient);
                    _services.Add(descriptor);
                }
            }

            return this;
        }
    }
}