

namespace JKCore.Mediator
{
    using JKCore.Mediator.Commands;
    using JKCore.Mediator.Exceptions;
    using Microsoft.Extensions.DependencyInjection;
    using System;

    /// <summary>
    /// Commmand handler.
    /// </summary>
    public class CommandHandlerProvider : ICommandHandlerProvider
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
        public CommandHandlerProvider(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        /// <summary>
        ///     The resolve async handler.
        /// </summary>
        /// <typeparam name="TCommand">
        /// </typeparam>
        /// <typeparam name="TResult">
        /// </typeparam>
        /// <returns>
        ///     The <see cref="IAsyncCommandHandler{TCommand, TREsult}" />.
        /// </returns>
        /// <exception cref="HandlerNotFound">
        /// </exception>
        public IAsyncCommandHandler<TCommand, TResult> ResolveAsyncHandler<TCommand, TResult>()
            where TCommand : IAsyncCommand<TResult>
        {
            var cmdType = typeof(TCommand);
            var handler = this._serviceProvider.GetService<IAsyncCommandHandler<TCommand, TResult>>();
            if (handler == null)
            {
                throw new HandlerNotFound(typeof(TCommand));
            }

            return handler;
        }

        /// <summary>
        /// Resolve async command handler.
        /// </summary>
        /// <typeparam name="TCommand"></typeparam>
        /// <returns>Async command handler that implements <see cref="IAsyncCommandHandler{TCommand}"/></returns>
        public IAsyncCommandHandler<TCommand> ResolveAsyncHandler<TCommand>() where TCommand : IAsyncCommand
        {
            var cmdType = typeof(TCommand);
        
            var handler = _serviceProvider.GetService<IAsyncCommandHandler<TCommand>>();
            if (handler == null)
            {
                throw new HandlerNotFound(typeof(TCommand));
            }

            return handler;
        }

       
        /// <summary>
        ///     The resolve handler.
        /// </summary>
        /// <typeparam name="TCommand">
        /// </typeparam>
        /// <typeparam name="TResult">
        /// </typeparam>
        /// <returns>
        ///     The <see cref="ICommandHandler" />.
        /// </returns>
        /// <exception cref="HandlerNotFound">
        /// </exception>
        public ICommandHandler<TCommand, TResult> ResolveHandler<TCommand, TResult>() where TCommand : ICommand<TResult>
        {
            var cmdType = typeof(TCommand);
            var handler = this._serviceProvider.GetService<ICommandHandler<TCommand, TResult>>();
            if (handler == null)
            {
                throw new HandlerNotFound(typeof(TCommand));
            }

            return handler;
        }

        /// <summary>
        ///     The resolve handler.
        /// </summary>
        /// <typeparam name="TCommand">
        /// </typeparam>
        /// <returns>
        ///     The <see cref="ICommandHandler" />.
        /// </returns>
        /// <exception cref="HandlerNotFound">
        /// </exception>
        public ICommandHandler<TCommand> ResolveHandler<TCommand>() where TCommand : ICommand
        {
            var cmdType = typeof(TCommand);

            var handler = this._serviceProvider.GetService<ICommandHandler<TCommand>>();
            if (handler == null)
            {
                throw new HandlerNotFound(typeof(TCommand));
            }

            return handler;
        }

    }
}
