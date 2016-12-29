// Copyright (c) Ho Nguyen. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace JKCore.MessageBus
{
    /// <summary>
    /// </summary>
    public interface IBodySerializer
    {
        /// <summary>
        /// </summary>
        /// <param name="obj">
        /// The obj.
        /// </param>
        /// <returns>
        /// </returns>
        byte[] Serialize(object obj);
    }
}