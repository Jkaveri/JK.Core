// Copyright (c) Ho Nguyen. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace JKCore.MessageBus.RabbitMQ
{
    /// <summary>
    /// </summary>
    public class RabbitMQConfiguration
    {
        /// <summary>
        /// Gets or sets the default exchange name.
        /// </summary>
        public string DefaultExchangeName { get; set; }

        /// <summary>
        /// Gets or sets the host name.
        /// </summary>
        public string HostName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether is durable exchange.
        /// </summary>
        public bool IsDurableExchange { get; set; }
    }
}