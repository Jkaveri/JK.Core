namespace JKCore.Mediator.Test.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using JKCore.Mediator.Commands;

    public class VoidAsyncCommand : IAsyncCommand
    {
        public Action Action { get; set; }
    }
}