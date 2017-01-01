﻿// Copyright (c) Ho Nguyen. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace JKCore.Mediator
{
    #region

    using JKCore.Extensions;
    using JKCore.Mediator.Commands;
    using JKCore.Mediator.Events;

    using Microsoft.Extensions.DependencyInjection;

    #endregion

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
            services.AddTransient<IMediator, Mediator>();
            services.AddTransient<ICommandHandlerResolver, MediatorRegister>();
            services.AddTransient<IEventListenerResolver, MediatorRegister>();
            return services;
        }

        /// <summary>
        /// </summary>
        /// <param name="services">
        /// The services.
        /// </param>
        /// <typeparam name="T">
        /// </typeparam>
        /// <returns>
        /// </returns>
        public static IServiceCollection AddMediatorTypesInAssemblyOf<T>(this IServiceCollection services)
        {
            services.Scan<T>(
                    collector => { collector.ImplementationOf(new[] { typeof(ICommandHandler), typeof(IEventListener) }); })
                .ByImplementedInterfaces();
            return services;
        }
    }
}