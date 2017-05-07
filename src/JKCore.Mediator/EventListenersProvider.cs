// Copyright (c) Ho Nguyen. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

#region

using System;
using System.Collections.Generic;
using System.Linq;
using JKCore.Mediator.Events;
using Microsoft.Extensions.DependencyInjection;

#endregion

namespace JKCore.Mediator
{
    #region

    #endregion

    /// <summary>
    ///     The event listener provider.
    /// </summary>
    public class EventListenersProvider : IEventListenersProvider
    {
        /// <summary>
        ///     The _container.
        /// </summary>
        private readonly IServiceProvider _serviceProvider;

        /// <summary>
        ///     Initializes a new instance of the <see cref="EventListenersProvider" /> class.
        /// </summary>
        /// <param name="serviceProvider">
        ///     The service Provider.
        /// </param>
        public EventListenersProvider(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        /// <summary>
        ///     The resolve listeners.
        /// </summary>
        /// <typeparam name="TMessage">
        /// </typeparam>
        /// <returns>
        ///     The <see cref="IEnumerable{T}" />.
        /// </returns>
        public IEnumerable<IEventListener<TMessage>> ResolveListeners<TMessage>() where TMessage : IEvent
        {
            var msgType = typeof(TMessage);
            List<IEventListener<TMessage>> receivers;
            try
            {
                receivers = _serviceProvider.GetServices<IEventListener<TMessage>>().ToList();
            }
            catch (Exception)
            {
                receivers = new List<IEventListener<TMessage>>();
            }

            return receivers;
        }

        /// <summary>
        ///     The resolve async listeners.
        /// </summary>
        /// <typeparam name="TMessage">
        /// </typeparam>
        /// <returns>
        ///     The <see cref="IEnumerable{T}" />.
        /// </returns>
        public IEnumerable<IAsyncEventListener<TMessage>> ResolveAsyncListeners<TMessage>() where TMessage : IAsyncEvent
        {
            var msgType = typeof(TMessage);
            List<IAsyncEventListener<TMessage>> receivers;

            try
            {
                receivers = _serviceProvider.GetServices<IAsyncEventListener<TMessage>>().ToList();
            }
            catch (Exception)
            {
                receivers = new List<IAsyncEventListener<TMessage>>();
            }

            return receivers;
        }
    }
}