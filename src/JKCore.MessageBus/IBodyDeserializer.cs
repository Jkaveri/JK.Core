// Copyright (c) Ho Nguyen. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace JKCore.MessageBus
{
    /// <summary>
    /// </summary>
    public interface IBodyDeserializer
    {
        /// <summary>
        /// </summary>
        /// <param name="body">
        /// The body.
        /// </param>
        /// <returns>
        /// </returns>
        object Deserialize(byte[] body);

        /// <summary>
        /// </summary>
        /// <param name="body">
        /// The body.
        /// </param>
        /// <typeparam name="T">
        /// </typeparam>
        /// <returns>
        /// </returns>
        T Deserialize<T>(byte[] body) where T : new();
    }
}