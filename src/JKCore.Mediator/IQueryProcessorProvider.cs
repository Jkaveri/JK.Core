namespace JKCore.Mediator
{
    using JKCore.Mediator.Queries;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Helps to resolve a query executor
    /// </summary>
    public interface IQueryProcessorProvider
    {
        /// <summary>
        /// Resolve a query processor.
        /// </summary>
        IQueryProcessor<TQuery, TResult> GetQueryProcessor<TQuery, TResult>() where TQuery : IQuery<TResult>;
    }
}
