// Copyright (c) Ho Nguyen. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace JKCore.MessageBus.RabbitMQ
{
    /// <summary>
    /// </summary>
    public class SendSettings
    {
        /// <summary>
        /// Gets or sets a value indicating whether durable.
        /// </summary>
        public bool Durable { get; set; }

        /// <summary>
        /// Gets or sets the exchange name.
        /// </summary>
        public string ExchangeName { get; set; }
    }
}