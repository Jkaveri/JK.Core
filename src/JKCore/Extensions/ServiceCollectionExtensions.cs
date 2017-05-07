using System.Collections.Generic;

namespace JKCore.Extensions
{
    #region

    using System;

    using JKCore.Extensions.Configuration;
    using JKCore.Utilities;

    using Microsoft.Extensions.DependencyInjection;

    #endregion

    /// <summary>
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// </summary>
        /// <param name="services">
        ///     The services.
        /// </param>
        /// <param name="collector">
        ///     The selector.
        /// </param>
        /// <typeparam name="T">
        /// </typeparam>
        /// <returns>
        /// </returns>
        public static ServiceRegister Scan<T>(this IServiceCollection services, Action<TypeCollector> collector = null)
        {
            var typeCollector = TypeCollector.Scan<T>();
            collector?.Invoke(typeCollector);
            return new ServiceRegister(typeCollector.Types, services);
        }
    }
}