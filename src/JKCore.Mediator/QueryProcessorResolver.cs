namespace JKCore.Mediator
{
    using System;
    using JKCore.Mediator.Queries;
    using Microsoft.Extensions.DependencyInjection;
    using JKCore.Mediator.Exceptions;

    /// <summary>
    /// Query processor resolver.
    /// </summary>
    public class QueryProcessorResolver : IQueryProcessorProvider
    {
        /// <summary>
        ///     The _container.
        /// </summary>
        private readonly IServiceProvider _serviceProvider;

        /// <summary>
        /// Construct query processor resolver.
        /// </summary>
        public QueryProcessorResolver(IServiceProvider sp)
        {
            _serviceProvider = sp;
        }

        /// <summary>
        /// Resolve query processor
        /// </summary>
        public IQueryProcessor<TQuery, TResult> GetQueryProcessor<TQuery, TResult>() where TQuery : IQuery<TResult>
        {
            var cmdType = typeof(TQuery);

            var handler = _serviceProvider.GetService<IQueryProcessor<TQuery, TResult>>();
            if (handler == null)
            {
                throw new QueryProcessorNotFound(typeof(TQuery));
            }

            return handler;
        }
    }
}
