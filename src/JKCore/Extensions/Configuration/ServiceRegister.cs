// Copyright (c) Ho Nguyen. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace JKCore.Extensions.Configuration
{
    #region

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    using JKCore.Utilities;

    using Microsoft.Extensions.DependencyInjection;

    #endregion

    /// <summary>
    /// </summary>
    public class ServiceRegister
    {
        private readonly IServiceCollection _services;

        private readonly IEnumerable<Type> _types;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ServiceRegister" /> class.
        /// </summary>
        public ServiceRegister(IEnumerable<Type> types, IServiceCollection services)
        {
            Check.ArgNotNull(types, nameof(types));
            Check.ArgNotNull(services, nameof(services));

            this._types = this.CollectImplementationClasses(types);
            this._services = services;
        }

        /// <summary>
        /// </summary>
        /// <param name="serviceLifetime">
        /// The service lifetime.
        /// </param>
        /// <returns>
        /// </returns>
        public ServiceRegister ByAbstractClasses(ServiceLifetime serviceLifetime = ServiceLifetime.Transient)
        {
            foreach (var type in this._types)
            {
                this.RegisterByBaseType(type, serviceLifetime);
            }

            return this;
        }

        /// <summary>
        /// </summary>
        public ServiceRegister ByImplementedInterfaces(ServiceLifetime serviceLifetime = ServiceLifetime.Transient)
        {
            var types = this._types.Where(t => t.GetTypeInfo().ImplementedInterfaces.Any());
            foreach (var type in types)
            {
                foreach (var @interface in type.GetTypeInfo().ImplementedInterfaces)
                {
                    this._services.Add(new ServiceDescriptor(@interface, type, serviceLifetime));
                }
            }

            return this;
        }

        /// <summary>
        /// </summary>
        /// <param name="serviceLifetime">
        ///     The service lifetime.
        /// </param>
        public ServiceRegister ByItSelf(ServiceLifetime serviceLifetime = ServiceLifetime.Transient)
        {
            foreach (var type in this._types)
            {
                this._services.Add(new ServiceDescriptor(type, type, serviceLifetime));
            }

            return this;
        }

        private IEnumerable<Type> CollectImplementationClasses(IEnumerable<Type> types)
        {
            return types.Where(this.IsImplementationClass);
        }

        private bool IsImplementationClass(Type type)
        {
            var info = type.GetTypeInfo();
            return info.IsClass && !info.IsAbstract;
        }

        private void RegisterByBaseType(Type type, ServiceLifetime serviceLifeTime = ServiceLifetime.Transient)
        {
            if (!this.IsImplementationClass(type))
            {
                return;
            }

            var info = type.GetTypeInfo();
            while (info.BaseType != null)
            {
                this._services.Add(new ServiceDescriptor(info.BaseType, type, serviceLifeTime));
                info = info.BaseType.GetTypeInfo();
            }
        }
    }
}