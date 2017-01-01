using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JKCore.Mediator.Test.Commands
{
    using JKCore.Mediator.Commands;

    public class ExpectedResultCommand : ICommand<object>
    {
        public object ExpectedResult { get; set; }
    }
}
