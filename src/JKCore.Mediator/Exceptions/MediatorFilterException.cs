#region

using System;

#endregion

namespace JKCore.Mediator.Exceptions
{
    public class MediatorFilterException : Exception
    {
        public MediatorFilterException(string message) : base(message)
        {
        }

        public MediatorFilterException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}