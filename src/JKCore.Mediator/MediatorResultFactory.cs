// Copyright (c) Ho Nguyen. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

#region

using System;
using System.Collections.Generic;
using JKCore.Mediator.Abstracts;
using JKCore.Models;

#endregion

namespace JKCore.Mediator
{
    /// <summary>
    /// </summary>
    public abstract class MediatorResultFactory<TResult>
    {
        /// <summary>
        ///     Fail result.
        /// </summary>
        protected IMediatorResult<TResult> Failure()
        {
            return new MediatorResult<TResult>(false);
        }

        /// <summary>
        ///     Fail result with inner data.
        /// </summary>
        protected IMediatorResult<TResult> Failure(TResult data)
        {
            return new MediatorResult<TResult>(false, data);
        }

        /// <summary>
        ///     Fail result with inner data and collection of <see cref="ErrorItem" />
        /// </summary>
        protected IMediatorResult<TResult> Failure(TResult data, IEnumerable<ErrorItem> errors)
        {
            IMediatorResult<TResult> result = Failure(data);

            result.AddErrors(errors);

            return result;
        }

        /// <summary>
        ///     Fail result with inner data and <see cref="ErrorItem" />
        /// </summary>
        protected IMediatorResult<TResult> Failure(TResult data, ErrorItem error)
        {
            return Failure(data, new[] {error});
        }

        /// <summary>
        ///     Fail result with inner data and message.
        /// </summary>
        protected IMediatorResult<TResult> Failure(TResult data, string message)
        {
            return Failure(data, new ErrorItem(message));
        }

        /// <summary>
        ///     Fail result with inner data and message and <see cref="Exception" />
        /// </summary>
        protected IMediatorResult<TResult> Failure(TResult data, string message, Exception exception)
        {
            return Failure(data, new ErrorItem(message, exception));
        }

        /// <summary>
        ///     Fail result with inner data and <see cref="Exception" />
        /// </summary>
        protected IMediatorResult<TResult> Failure(TResult data, Exception exception)
        {
            return Failure(data, new ErrorItem(exception));
        }


        /// <summary>
        ///     Fail result with message.
        /// </summary>
        protected IMediatorResult<TResult> Failure(string message)
        {
            return Failure(new ErrorItem(message));
        }

        /// <summary>
        ///     Fail result with message and <see cref="Exception" />
        /// </summary>
        protected IMediatorResult<TResult> Failure(string message, Exception exception)
        {
            return Failure(new ErrorItem(message, exception));
        }

        /// <summary>
        ///     Fail result with <see cref="Exception" />
        /// </summary>
        protected IMediatorResult<TResult> Failure(Exception exception)
        {
            return Failure(new ErrorItem(exception));
        }

        /// <summary>
        ///     Fail result with collection of <see cref="ErrorItem" />
        /// </summary>
        protected IMediatorResult<TResult> Failure(IEnumerable<ErrorItem> errors)
        {
            var result = Failure();
            result.AddErrors(errors);
            return result;
        }

        /// <summary>
        ///     Fail result with error item.
        /// </summary>
        protected IMediatorResult<TResult> Failure(ErrorItem error)
        {
            return Failure(new[] {error});
        }

        /// <summary>
        ///     Success result.
        /// </summary>
        protected IMediatorResult<TResult> Success()
        {
            return new MediatorResult<TResult>(true);
        }

        /// <summary>
        ///     Success result with inner data.
        /// </summary>
        protected IMediatorResult<TResult> Success(TResult data)
        {
            return new MediatorResult<TResult>(true, data);
        }
    }

}