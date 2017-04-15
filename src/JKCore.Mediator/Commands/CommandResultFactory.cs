using System;
using System.Collections.Generic;
using JKCore.Models;

namespace JKCore.Mediator.Commands
{
    #region

    #endregion

    /// <summary>
    /// </summary>
    /// <typeparam name="TResult">
    /// </typeparam>
    public abstract class CommandResultFactory<TResult>
    {
        /// <summary>
        ///     Fail result.
        /// </summary>
        protected ICommandResult<TResult> Failure()
        {
            return new CommandResult<TResult>(false);
        }

        /// <summary>
        ///     Fail result with inner data.
        /// </summary>
        protected ICommandResult<TResult> Failure(TResult data)
        {
            return new CommandResult<TResult>(false, data);
        }

        /// <summary>
        ///     Fail result with inner data and collection of <see cref="ErrorItem" />
        /// </summary>
        protected ICommandResult<TResult> Failure(TResult data, IEnumerable<ErrorItem> errors)
        {
            ICommandResult<TResult> result = Failure(data);

            result.AddErrors(errors);

            return result;
        }

        /// <summary>
        ///     Fail result with inner data and <see cref="ErrorItem" />
        /// </summary>
        protected ICommandResult<TResult> Failure(TResult data, ErrorItem error)
        {
            return Failure(data, new[] { error });
        }

        /// <summary>
        ///     Fail result with inner data and message.
        /// </summary>
        protected ICommandResult<TResult> Failure(TResult data, string message)
        {
            return Failure(data, new ErrorItem(message));
        }

        /// <summary>
        ///     Fail result with inner data and message and <see cref="Exception" />
        /// </summary>
        protected ICommandResult<TResult> Failure(TResult data, string message, Exception exception)
        {
            return Failure(data, new ErrorItem(message, exception));
        }

        /// <summary>
        ///     Fail result with inner data and <see cref="Exception" />
        /// </summary>
        protected ICommandResult<TResult> Failure(TResult data, Exception exception)
        {
            return Failure(data, new ErrorItem(exception));
        }


        /// <summary>
        ///     Fail result with message.
        /// </summary>
        protected ICommandResult<TResult> Failure(string message)
        {
            return Failure(new ErrorItem(message));
        }

        /// <summary>
        ///     Fail result with message and <see cref="Exception" />
        /// </summary>
        protected ICommandResult<TResult> Failure(string message, Exception exception)
        {
            return Failure(new ErrorItem(message, exception));
        }

        /// <summary>
        ///     Fail result with <see cref="Exception" />
        /// </summary>
        protected ICommandResult<TResult> Failure(Exception exception)
        {
            return Failure(new ErrorItem(exception));
        }

        /// <summary>
        ///     Fail result with collection of <see cref="ErrorItem" />
        /// </summary>
        protected ICommandResult<TResult> Failure(IEnumerable<ErrorItem> errors)
        {
            ICommandResult<TResult> result = Failure();
            result.AddErrors(errors);
            return result;
        }

        /// <summary>
        ///     Fail result with error item.
        /// </summary>
        protected ICommandResult<TResult> Failure(ErrorItem error)
        {
            return Failure(new[] { error });
        }

        /// <summary>
        /// Success result.
        /// </summary>
        protected ICommandResult<TResult> Success()
        {
            return new CommandResult<TResult>(true);
        }

        /// <summary>
        /// Success result with inner data.
        /// </summary>
        protected ICommandResult<TResult> Success(TResult data)
        {
            return new CommandResult<TResult>(true, data);
        }
    }


    /// <summary>
    /// </summary>
    public abstract class CommandResultFactory
    {
        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        protected ICommandResult Failure()
        {
            return new CommandResult(false);
        }

        /// <summary>
        /// </summary>
        /// <param name="message">
        ///     The message.
        /// </param>
        /// <returns>
        /// </returns>
        protected ICommandResult Failure(string message)
        {
            ICommandResult result = Failure();
            result.AddError(message);
            return result;
        }

        /// <summary>
        /// </summary>
        /// <param name="message">
        ///     The message.
        /// </param>
        /// <param name="exception">
        ///     The exception.
        /// </param>
        /// <returns>
        /// </returns>
        protected ICommandResult Failure(string message, Exception exception)
        {
            ICommandResult result = Failure();
            result.AddError(message, exception);
            return result;
        }

        /// <summary>
        /// </summary>
        /// <param name="exception">
        ///     The exception.
        /// </param>
        /// <returns>
        /// </returns>
        protected ICommandResult Failure(Exception exception)
        {
            ICommandResult result = Failure();
            result.AddError(exception);
            return result;
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        protected ICommandResult Success()
        {
            return new CommandResult(true);
        }
    }
}