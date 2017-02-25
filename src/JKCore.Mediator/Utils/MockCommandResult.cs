namespace JKCore.Mediator.Utils
{
    using System;

    using JKCore.Mediator.Commands;

    /// <summary>
    /// A utils that help you create a command result in a test method.
    /// </summary>
    public static class MockCommandResult
    {
        /// <summary>
        /// Create failure result.
        /// </summary>
        public static ICommandResult<TResult> Failure<TResult>()
        {
            return new CommandResult<TResult>(false);
        }

        /// <summary>
        /// Create failure result with a message.
        /// </summary>
        public static ICommandResult<TResult> Failure<TResult>(string message)
        {
            var result = Failure<TResult>();
            result.AddError(message);
            return result;
        }

        /// <summary>
        /// Create failure result with a message and an exception.
        /// </summary>
        public static ICommandResult<TResult> Failure<TResult>(string message, Exception exception)
        {
            var result = Failure<TResult>();
            result.AddError(message, exception);
            return result;
        }

        /// <summary>
        /// Create failure result with an exception.
        /// </summary>
        public static ICommandResult<TResult> Failure<TResult>(Exception exception)
        {
            var result = Failure<TResult>();
            result.AddError(exception);
            return result;
        }

        /// <summary>
        /// Create a success result.
        /// </summary>
        public static ICommandResult<TResult> Success<TResult>(TResult result)
        {
            return new CommandResult<TResult>(true, result);
        }

        /// <summary>
        /// Create success result.
        /// </summary>
        public static ICommandResult<TResult> Success<TResult>()
        {
            return new CommandResult<TResult>(true);
        }
    }
}