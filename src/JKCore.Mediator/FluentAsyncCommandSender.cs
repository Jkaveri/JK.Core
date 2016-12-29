// Copyright (c) Ho Nguyen. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace JK.Core.Mediator
{
    #region

    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using JK.Core.Mediator.Commands;

    #endregion

    /// <summary>
    ///     The fluent async command sender.
    /// </summary>
    /// <typeparam name="TCommand">
    /// </typeparam>
    /// <typeparam name="TResult">
    /// </typeparam>
    public class FluentAsyncCommandSender<TCommand, TResult>
        where TCommand : IAsyncCommand<TResult>
    {
        /// <summary>
        ///     The _after send.
        /// </summary>
        private readonly List<Func<TCommand, TResult, Task<TResult>>> _afterSend;

        /// <summary>
        ///     The _before send.
        /// </summary>
        private readonly List<Func<TCommand, Task<bool>>> _beforeSend;

        /// <summary>
        ///     The _mediator.
        /// </summary>
        private readonly IMediator _mediator;

        /// <summary>
        ///     Initializes a new instance of the <see cref="FluentAsyncCommandSender{TCommand,TResult}" /> class.
        /// </summary>
        /// <param name="mediator">
        ///     The mediator.
        /// </param>
        public FluentAsyncCommandSender(IMediator mediator)
        {
            this._mediator = mediator;
            this._beforeSend = new List<Func<TCommand, Task<bool>>>();
            this._afterSend = new List<Func<TCommand, TResult, Task<TResult>>>();
        }

        /// <summary>
        ///     The after send.
        /// </summary>
        /// <param name="function">
        ///     The after send anonymous function.
        /// </param>
        /// <returns>
        ///     The <see />.
        /// </returns>
        public FluentAsyncCommandSender<TCommand, TResult> AfterSend(Func<TCommand, TResult, Task<TResult>> function)
        {
            this._afterSend.Add(function);
            return this;
        }

        /// <summary>
        ///     The before send.
        /// </summary>
        /// <param name="function">
        ///     The after send anonymous function.
        /// </param>
        /// <returns>
        ///     The <see cref="FluentAsyncCommandSender{TCommand,TResult}" />
        /// </returns>
        public FluentAsyncCommandSender<TCommand, TResult> BeforeSend(Func<TCommand, Task<bool>> function)
        {
            this._beforeSend.Add(function);
            return this;
        }

        /// <summary>
        ///     The send.
        /// </summary>
        /// <param name="command">
        ///     The command.
        /// </param>
        /// <returns>
        ///     The <see cref="Task" />.
        /// </returns>
        public async Task<TResult> Send(TCommand command)
        {
            var @continue = await this.Execute(this._beforeSend, command);
            if (@continue)
            {
                var result = await this._mediator.SendAsync<TCommand, TResult>(command);

                if (this._afterSend != null)
                {
                    result = await this.Execute(this._afterSend, command);
                }

                return result;
            }

            return default(TResult);
        }

        /// <summary>
        ///     The execute.
        /// </summary>
        /// <param name="handlers">
        ///     The handlers.
        /// </param>
        /// <param name="command">
        ///     The command.
        /// </param>
        /// <returns>
        ///     The <see cref="Task" />.
        /// </returns>
        private async Task<bool> Execute(List<Func<TCommand, Task<bool>>> handlers, TCommand command)
        {
            var i = 0;
            while (i < handlers.Count)
            {
                if (!await handlers[i++](command))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        ///     The execute.
        /// </summary>
        /// <param name="handlers">
        ///     The handlers.
        /// </param>
        /// <param name="command">
        ///     The command.
        /// </param>
        /// <returns>
        ///     The <see cref="Task" />.
        /// </returns>
        private async Task<TResult> Execute(List<Func<TCommand, TResult, Task<TResult>>> handlers, TCommand command)
        {
            var i = 0;
            var result = default(TResult);
            while (i < handlers.Count)
            {
                result = await handlers[i++](command, result);
            }

            return result;
        }
    }
}