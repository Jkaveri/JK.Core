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