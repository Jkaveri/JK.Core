#region

using System;
using JKCore.Mediator.Abstracts;

#endregion

namespace JKCore.Mediator.Test.Messages
{
    public class FakeMessage : IMessage<bool>
    {
        public Action Action { get; set; }
    }
}