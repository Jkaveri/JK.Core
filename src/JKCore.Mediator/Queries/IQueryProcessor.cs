
namespace JKCore.Mediator.Queries
{
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Query processor
    /// </summary>
    public interface IQueryProcessor<TQuery, TResult> : IQueryProcessor where TQuery: IQuery<TResult>
    {
        /// <summary>
        /// Execute query and return a result.
        /// </summary>
        /// <returns></returns>
        Task<TResult> ExecuteAsync(TQuery query, CancellationToken cancellationToken = default(CancellationToken));
    }

    /// <summary>
    /// Query processor interface.
    /// </summary>
    public interface IQueryProcessor { }
}
