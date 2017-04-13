using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JKCore
{
    using JKCore.Validators;

    using Microsoft.Extensions.DependencyInjection;

    public static class JKCoreServiceCollectionExtensions
    {
        public static IServiceCollection AddJKCore(this IServiceCollection services)
        {
            services.AddTransient<AnnotationsValidator>();

            return services;
        }
    }
}
