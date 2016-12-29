// Copyright (c) Ho Nguyen. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace JK.Core.Mediator
{
    #region

    using System;
    using System.Collections.Generic;

    using JK.Core.Mediator.Commands;

    #endregion

    /// <summary>
    /// </summary>
    /// <typeparam name="TCommand">
    /// </typeparam>
    /// <typeparam name="TResult">
    /// </typeparam>
    public class FluentCommandSender<TCommand, TResult>
        where TCommand : ICommand<TResult>
    {
        private readonly List<Func<TCommand, TResult, TResult>> _afterSend;

        private readonly List<Func<TCommand, bool>> _beforeSend;

        private IMediator _mediator;

        /// <summary>
        /// Initializes a new instance of the <see cref="FluentCommandSender{TCommand,TResult}"/> class.
        /// </summary>
        /// <param name="mediator">
        /// The mediator.
        /// </param>
        public FluentCommandSender(IMediator mediator)
        {
            this._mediator = mediator;
            this._beforeSend = new List<Func<TCommand, bool>>();
            this._afterSend = new List<Func<TCommand, TResult, TResult>>();
        }

        /// <summary>
        /// </summary>
        /// <param name="func">
        /// The func.
        /// </param>
        /// <returns>
        /// </returns>
        public FluentCommandSender<TCommand, TResult> AfterSend(Func<TCommand, TResult, TResult> func)
        {
            this._afterSend.Add(func);
            return this;
        }

        /// <summary>
        /// </summary>
        /// <param name="func">
        /// The func.
        /// </param>
        /// <returns>
        /// </returns>
        public FluentCommandSender<TCommand, TResult> BeforeSend(Func<TCommand, bool> func)
        {
            this._beforeSend.Add(func);
            return this;
        }

        /// <summary>
        /// </summary>
        /// <param name="command">
        /// The command.
        /// </param>
        /// <returns>
        /// </returns>
        public TResult Send(TCommand command)
        {
            var @continue = this.Execute(this._beforeSend, command);

            if (@continue)
            {
                var result = this._mediator.Send<TCommand, TResult>(command);

                if (this._afterSend != null)
                {
                    result = this.Execute(this._afterSend, command);
                }

                return result;
            }

            return default(TResult);
        }

        private bool Execute(List<Func<TCommand, bool>> handlers, TCommand command)
        {
            var i = 0;
            while (i < handlers.Count)
            {
                if (!handlers[i++](command))
                {
                    return false;
                }
            }

            return true;
        }

        private TResult Execute(List<Func<TCommand, TResult, TResult>> handlers, TCommand command)
        {
            var i = 0;
            var result = default(TResult);
            while (i < handlers.Count)
            {
                result = handlers[i++](command, result);
            }

            return result;
        }
    }
}