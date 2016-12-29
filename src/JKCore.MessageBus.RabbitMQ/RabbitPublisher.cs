// Copyright (c) Ho Nguyen. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace JKCore.MessageBus.RabbitMQ
{
    #region

    using System;
    using System.Threading.Tasks;

    using global::RabbitMQ.Client;

    #endregion

    /// <summary>
    /// </summary>
    public class RabbitPublisher : IPublisher, IDisposable
    {
        private ConnectionFactory _connectionFactory;

        private RabbitModelContext _modelContext;

        private SendSettings _sendSettings;

        private IBodySerializer _serializer;

        /// <summary>
        /// Initializes a new instance of the <see cref="RabbitPublisher"/> class.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        /// <param name="sendSettings">
        /// The send settings.
        /// </param>
        /// <param name="serializer">
        /// The serializer.
        /// </param>
        public RabbitPublisher(RabbitModelContext context, SendSettings sendSettings, IBodySerializer serializer)
        {
            this._modelContext = context;
            this._sendSettings = sendSettings;
            this._serializer = serializer;
        }

        /// <summary>
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
        }

        /// <summary>
        /// </summary>
        /// <param name="key">
        /// The key.
        /// </param>
        /// <param name="msg">
        /// The msg.
        /// </param>
        /// <returns>
        /// </returns>
        public async Task Publish(string key, object msg)
        {
            var channel = await this._modelContext.GetModel();

            var routingkey = key;
            var body = this._serializer.Serialize(msg);

            var properties = channel.CreateBasicProperties();
            properties.Persistent = this._sendSettings.Durable;

            channel.BasicPublish(this._sendSettings.ExchangeName, routingkey, null, body);
        }

        /// <summary>
        /// </summary>
        /// <param name="msg">
        /// The msg.
        /// </param>
        /// <typeparam name="T">
        /// </typeparam>
        /// <returns>
        /// </returns>
        public Task Publish<T>(object msg)
        {
            var type = typeof(T);
            var name = type.FullName;
            return this.Publish(name, msg);
        }

        /// <summary>
        /// </summary>
        /// <param name="disposing">
        /// The disposing.
        /// </param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
            }
        }
    };
}