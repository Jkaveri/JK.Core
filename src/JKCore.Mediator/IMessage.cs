// Copyright (c) Ho Nguyen. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace JKCore.Mediator
{
    /// <summary>
    /// An interface of message.
    /// </summary>
    public interface IMessage
    {
    }

    /// <summary>
    /// An interface of message which will return result.
    /// </summary>
    public interface IMessage<TResult> : IMessage
    {
    }
}