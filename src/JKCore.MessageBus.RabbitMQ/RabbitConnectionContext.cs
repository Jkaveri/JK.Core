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
    public class RabbitConnectionContext : IDisposable
    {
        private IConnection _connection;

        private ConnectionFactory _connectionFactory;

        private bool _disposed;

        /// <summary>
        /// Initializes a new instance of the <see cref="RabbitConnectionContext"/> class.
        /// </summary>
        /// <param name="connectionFactory">
        /// The connection factory.
        /// </param>
        public RabbitConnectionContext(ConnectionFactory connectionFactory)
        {
            this._connectionFactory = connectionFactory;
        }

        /// <summary>
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public Task<IConnection> GetConnection()
        {
            if (this._connection != null)
            {
                return Task.FromResult(this._connection);
            }

            return Task.Run(() => { return this._connection = this._connectionFactory.CreateConnection(); });
        }

        private void Dispose(bool disposing)
        {
            if (this._disposed) return;

            if (disposing)
            {
                this._disposed = true;
                if (this._connection != null)
                {
                    try
                    {
                        this._connection.Dispose();
                    }
                    catch (Exception)
                    {
                    }
                }
            }
        }
    }
}