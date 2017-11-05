using System;
using System.Collections.Generic;
using System.Text;

namespace JKCore.Mediator.Test.Shared
{
    public class ScopedService
    {
        public ScopedService()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
    }
}
