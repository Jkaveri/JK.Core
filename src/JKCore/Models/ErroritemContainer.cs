// Copyright (c) Ho Nguyen. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace JKCore.Models
{
    #region

    using System;
    using System.Collections.Generic;

    #endregion

    /// <summary>
    /// </summary>
    public class ErroritemContainer : IErrorItemContainer
    {
        private readonly List<ErrorItem> _errorItems = new List<ErrorItem>();

        /// <summary>
        ///     Gets the errors.
        /// </summary>
        public IReadOnlyList<ErrorItem> Errors => this._errorItems;

        /// <summary>
        ///     The add error.
        /// </summary>
        /// <param name="msg">
        ///     The error message.
        /// </param>
        public void AddError(string msg)
        {
            if (string.IsNullOrEmpty(msg))
            {
                return;
            }

            this._errorItems.Add(new ErrorItem(msg));
        }

        /// <summary>
        ///     Add an error item with an exception.
        /// </summary>
        /// <param name="exception"></param>
        public void AddError(Exception exception)
        {
            if (exception == null)
            {
                return;
            }

            this._errorItems.Add(new ErrorItem(exception));
        }

        /// <summary>
        ///     The add error item with message and exception.
        /// </summary>
        /// <param name="msg">
        ///     The error message.
        /// </param>
        /// <param name="ex">
        ///     The ex.
        /// </param>
        public void AddError(string msg, Exception ex)
        {
            this._errorItems.Add(new ErrorItem(msg, ex));
        }

        /// <summary>
        ///     The add errors.
        /// </summary>
        /// <param name="errors">
        ///     The errors.
        /// </param>
        public void AddErrors(IEnumerable<ErrorItem> errors)
        {
            if (errors != null)
            {
                this._errorItems.AddRange(errors);
            }
        }
    }
}