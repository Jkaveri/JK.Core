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
    public class RabbitModelContext : IDisposable
    {
        private RabbitConnectionContext _connectionContext;

        private bool _disposed;

        private IModel _model;

        /// <summary>
        /// Initializes a new instance of the <see cref="RabbitModelContext"/> class.
        /// </summary>
        /// <param name="connextionContext">
        /// The connextion context.
        /// </param>
        public RabbitModelContext(RabbitConnectionContext connextionContext)
        {
            this._connectionContext = connextionContext;
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
        public async Task<IModel> GetModel()
        {
            if (this._model != null)
            {
                return this._model;
            }

            var connection = await this._connectionContext.GetConnection();
            return await Task.Run(() => { return this._model = connection.CreateModel(); });
        }

        private void Dispose(bool v)
        {
            if (this._disposed)
            {
                return;
            }

            if (v)
            {
                this._disposed = true;
                try
                {
                    this._model?.Dispose();
                }
                catch (Exception)
                {
                }
            }
        }
    }
}