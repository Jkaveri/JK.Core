// Copyright (c) Ho Nguyen. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

#region

using System.Linq;
using System.Reflection;
using JKCore.Utilities;
using Microsoft.Extensions.DependencyInjection;
using static JKCore.Utilities.ReflectionUtils;

#endregion

namespace JKCore.Mediator
{
    /// <summary>
    /// </summary>
    public static class MediatorServiceCollectionExtensions
    {
        /// <summary>
        /// </summary>
        /// <param name="services">
        ///     The services.
        /// </param>
        /// <returns>
        /// </returns>
        public static IServiceCollection AddMediator(this IServiceCollection services)
        {
            services.AddSingleton<IMediator, Mediator>();
            services.AddSingleton<IHandlerResolver>((sp) => new HandlerResolver(sp));
            return services;
        }

        /// <summary>
        /// </summary>
        /// <param name="services">
        ///     The services.
        /// </param>
        /// <typeparam name="T">
        /// </typeparam>
        /// <returns>
        /// </returns>
        public static IServiceCollection AddMediatorTypesInAssemblyOf<T>(this IServiceCollection services)
        {
            var result = TypeCollector.Scan<T>()
                .Types
                .Where(type => IsAssignAbleTo(type, typeof(IMediatorHandler)));

            foreach (var type in result)
            {
                // Add it selft
                services.Add(new ServiceDescriptor(type, type, ServiceLifetime.Transient));

                // Implemented interface
                foreach (var @interface in type.GetTypeInfo().ImplementedInterfaces)
                {
                    var descriptor = new ServiceDescriptor(@interface, type, ServiceLifetime.Transient);
                    services.Add(descriptor);
                }
            }

            return services;
        }
    }
}