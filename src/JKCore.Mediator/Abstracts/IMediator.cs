// Copyright (c) Ho Nguyen. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

#region

using System.Threading;
using System.Threading.Tasks;

#endregion

namespace JKCore.Mediator.Abstracts
{
    #region

    #endregion

    /// <summary>
    /// </summary>
    public interface IMediator
    {
        /// <summary>
        ///     Sends command asynchronous.
        /// </summary>
        Task<IMediatorResult<TResult>> Send<TResult>(IMessage<TResult> message,
            CancellationToken cancellationToken = default(CancellationToken));
    }
}