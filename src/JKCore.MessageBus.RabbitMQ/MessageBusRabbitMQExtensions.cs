// Copyright (c) Ho Nguyen. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace JKCore.MessageBus.RabbitMQ
{
    #region

    using System;

    using global::RabbitMQ.Client;

    using Microsoft.Extensions.DependencyInjection;

    #endregion

    /// <summary>
    /// </summary>
    public static class MessageBusRabbitMQExtensions
    {
        /// <summary>
        /// </summary>
        /// <param name="builder">
        ///     The builder.
        /// </param>
        /// <param name="configurationFactory">
        ///     The configuration factory.
        /// </param>
        public static void UseRabbitMQMessageBus(
            this IServiceCollection builder,
            Func<RabbitMQConfiguration> configurationFactory)
        {
            // builder.RegisterModule<MessageBusRabbitMQAutofacModule>();

            var config = configurationFactory();

            builder.AddSingleton(
                (ctx) =>
                    {
                        var connectionFactory = new ConnectionFactory { HostName = config.HostName, };
                        return connectionFactory;
                    });

            builder.AddSingleton(
                (ctx) =>
                    new SendSettings
                        {
                            ExchangeName = config.DefaultExchangeName, Durable = config.IsDurableExchange,
                        });
        }
    }
}