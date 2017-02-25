namespace JKCore.Mediator.Commands
{
    #region

    using JKCore.Models;

    #endregion

    /// <summary>
    /// </summary>
    /// <typeparam name="TResult">
    /// </typeparam>
    public class CommandResult<TResult> : ErroritemContainer, ICommandResult<TResult>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CommandResult{TResult}"/> class.
        /// </summary>
        /// <param name="succeed">
        /// The succeed.
        /// </param>
        public CommandResult(bool succeed)
            : this(succeed, default(TResult))
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
        public CommandResult(bool succeed, TResult result)
        {
            this.Succeed = succeed;
            this.Data = result;
        }

        /// <summary>
        ///     Gets the result.
        /// </summary>
        public TResult Data { get; }

        /// <summary>
        ///     Gets a value indicating whether succeed.
        /// </summary>
        public bool Succeed { get; }
    }
}