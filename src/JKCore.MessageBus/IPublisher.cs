// Copyright (c) Ho Nguyen. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace JKCore.MessageBus
{
    #region

    using System.Threading.Tasks;

    #endregion

    /// <summary>
    /// </summary>
    public interface IPublisher
    {
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
        Task Publish(string key, object msg);

        /// <summary>
        /// </summary>
        /// <param name="msg">
        /// The msg.
        /// </param>
        /// <typeparam name="T">
        /// </typeparam>
        /// <returns>
        /// </returns>
        Task Publish<T>(object msg);
    }
}