namespace JKCore.Models
{
    #region

    using System;
    using System.Collections.Generic;

    #endregion

    /// <summary>
    ///     Interface of error item container.
    /// </summary>
    public interface IErrorItemContainer
    {
        /// <summary>
        /// Gets the errors.
        /// </summary>
        IReadOnlyList<ErrorItem> Errors { get; }

        /// <summary>
        ///     Add error with a message.
        /// </summary>
        /// <param name="message">
        ///     The message.
        /// </param>
        void AddError(string message);

        /// <summary>
        ///     Add error with a exception.
        /// </summary>
        /// <param name="exception">
        ///     The exception.
        /// </param>
        void AddError(Exception exception);

        /// <summary>
        /// </summary>
        /// <param name="message">
        ///     The message.
        /// </param>
        /// <param name="ex">
        ///     The ex.
        /// </param>
        void AddError(string message, Exception ex);

        /// <summary>
        /// </summary>
        /// <param name="errors">
        ///     The errors.
        /// </param>
        void AddErrors(IEnumerable<ErrorItem> errors);
    }
}