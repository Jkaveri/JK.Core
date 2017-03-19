namespace JKCore.Mediator.Test.Commands
{
    using JKCore.Mediator.Commands;
    using System;

    public class VoidCommand : ICommand
    {
        public Action Action { get; set; }  
    }
}