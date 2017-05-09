// Copyright (c) Ho Nguyen. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

#region

using System.Linq;
using System.Reflection;
using JKCore.Mediator.Abstracts;
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
        public static MediatorServicesBuilder AddMediator(this IServiceCollection services)
        {
            services.AddSingleton<IMediator, Mediator>();
            services.AddSingleton<IHandlerResolver>((sp) => new HandlerResolver(sp));
            services.AddSingleton<FilterManager>();
            return new MediatorServicesBuilder(services);
        }
    }
}