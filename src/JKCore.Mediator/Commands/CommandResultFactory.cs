namespace JKCore.Mediator.Commands
{
    #region

    using System;

    #endregion

    /// <summary>
    /// </summary>
    /// <typeparam name="TResult">
    /// </typeparam>
    public abstract class CommandResultFactory<TResult>
    {
        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        protected ICommandResult<TResult> Failure()
        {
            return new CommandResult<TResult>(false);
        }

        /// <summary>
        /// </summary>
        /// <param name="message">
        ///     The message.
        /// </param>
        /// <returns>
        /// </returns>
        protected ICommandResult<TResult> Failure(string message)
        {
            var result = this.Failure();
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
        protected ICommandResult<TResult> Failure(string message, Exception exception)
        {
            var result = this.Failure();
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
        protected ICommandResult<TResult> Failure(Exception exception)
        {
            var result = this.Failure();
            result.AddError(exception);
            return result;
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        protected ICommandResult<TResult> Success()
        {
            return new CommandResult<TResult>(true);
        }

        /// <summary>
        /// </summary>
        /// <param name="result">
        ///     The result.
        /// </param>
        /// <returns>
        /// </returns>
        protected ICommandResult<TResult> Success(TResult result)
        {
            return new CommandResult<TResult>(true, result);
        }
    }
}