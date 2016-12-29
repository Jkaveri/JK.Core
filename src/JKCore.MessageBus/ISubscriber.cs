// Copyright (c) Ho Nguyen. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace JKCore.MessageBus
{
    #region

    using System;

    #endregion

    /// <summary>
    /// </summary>
    public interface ISubscriber
    {
        /// <summary>
        /// </summary>
        /// <param name="key">
        /// The key.
        /// </param>
        /// <param name="handler">
        /// The handler.
        /// </param>
        void Subscribe(string key, Action<object> handler);
    }
}