namespace JKCore.Mediator.Exceptions
{
    using System;

    /// <summary>
    /// QU
    /// </summary>
    public class QueryProcessorNotFound :Exception
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="QueryProcessorNotFound" /> class.
        /// </summary>
        /// <param name="queryType">
        ///     The cmd type.
        /// </param>
        public QueryProcessorNotFound(Type queryType)
            : base($"Handler for {queryType.FullName} not found")
        {
            this.QueryType = queryType;
        }

        /// <summary>
        ///     Gets the command type.
        /// </summary>
        public Type QueryType { get; private set; }
    }
}
