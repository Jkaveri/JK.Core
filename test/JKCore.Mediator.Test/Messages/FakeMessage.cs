#region

using System;

#endregion

namespace JKCore.Mediator.Test.Messages
{
    public class FakeMessage : IMessage
    {
        public Action Action { get; set; }
    }
}