using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JKCore.Mediator.Abstracts;

namespace JKCore.Mediator.Test.Messages
{
    public interface IExpectedMessage : IMessage<object>
    {
        object Expected { get; }
    }

    public class ExpectedMessage : IExpectedMessage, IMessage
    {
        public object Expected { get; set; }
    }
}
