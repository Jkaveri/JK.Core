using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
