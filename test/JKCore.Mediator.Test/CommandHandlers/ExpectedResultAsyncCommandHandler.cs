﻿namespace JKCore.Mediator.Test.CommandHandlers
{
    using System;
    using System.Threading;
    #region

    using System.Threading.Tasks;

    using JKCore.Mediator.Commands;
    using JKCore.Mediator.Test.Commands;

    #endregion

    public class ExpectedResultAsyncCommandHandler : AsyncCommandHandler<ExpectedResultAsyncCommand, object>
    {
        public override Task<ICommandResult<object>> HandleAsync(ExpectedResultAsyncCommand command, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.FromResult(this.Success(command.ExpectedResult));
        }
        
    }
}