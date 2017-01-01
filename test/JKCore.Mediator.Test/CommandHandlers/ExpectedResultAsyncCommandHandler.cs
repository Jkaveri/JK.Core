using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JKCore.Mediator.Test.CommandHandlers
{
    using JKCore.Mediator.Commands;
    using JKCore.Mediator.Test.Commands;
    public class ExpectedResultAsyncCommandHandler : IAsyncCommandHandler<ExpectedResultAsyncCommand, object>
    {
        /// <summary>
        /// </summary>
        /// <param name="command">
        /// The command.
        /// </param>
        /// <returns>
        /// </returns>
        public Task<object> Handle(ExpectedResultAsyncCommand command)
        {
            return Task.FromResult(command.ExpectedResult);
        }
    }
}
