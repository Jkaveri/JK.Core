namespace JKCore.Mediator.Commands
{
    /// <summary>
    ///     Anonymous command result.
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    public class AnoCommandResult<TResult> : CommandResult<TResult>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="CommandResult{TResult}" /> class.
        /// </summary>
        /// <param name="succeed">
        ///     The succeed.
        /// </param>
        public AnoCommandResult(bool succeed)
            : base(succeed)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="CommandResult{TResult}" /> class.
        /// </summary>
        /// <param name="succeed">
        ///     The succeed.
        /// </param>
        /// <param name="result">
        ///     The result.
        /// </param>
        public AnoCommandResult(bool succeed, TResult result)
            : base(succeed, result)
        {
        }
    }
}