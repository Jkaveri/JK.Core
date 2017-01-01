﻿namespace JKCore.All.Default
{
    #region

    using JKCore.Extensions;
    using JKCore.Extensions.Configuration;
    using JKCore.Mediator;
    using JKCore.Models;
    using JKCore.Utilities;
    using JKCore.Validators;
    using JKCore.Validators.Models;

    using Microsoft.Extensions.DependencyInjection;

    #endregion

    /// <summary>
    ///     Service Collection Extensions
    /// </summary>
    public static class JKCoreDefaultServiceCollectionExtensions
    {
        /// <summary>
        /// </summary>
        /// <param name="services">
        ///     The services.
        /// </param>
        public static void AddJKCore(this ServiceCollection services)
        {
            services.AddTransient<AnnotationsValidator>();

            // Add mediator
            services.AddMediator();
            // services.Scan<AnnotationsValidator>(
            //    collector =>
            //        {
            //            collector.Ignore<ServiceRegister>();
            //            collector.Ignore<ValidationResult>();
            //            collector.Ignore<TypeCollector>();
            //            collector.Ignore<ErrorItem>();
            //        }).ByItSelf();
        }
    }
}