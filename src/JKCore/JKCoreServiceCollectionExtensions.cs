// Copyright (c) Ho Nguyen. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

#region

using JKCore.Validators;
using Microsoft.Extensions.DependencyInjection;

#endregion

namespace JKCore
{
    /// <summary>
    ///     Extendsions
    /// </summary>
    public static class JKCoreServiceCollectionExtensions
    {
        public static IServiceCollection AddJKCore(this IServiceCollection services)
        {
            services.AddTransient<AnnotationsValidator>();

            return services;
        }
    }
}