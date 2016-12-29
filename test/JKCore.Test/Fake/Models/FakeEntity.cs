using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JKCore.Test.Fake
{
    using JKCore.Modeling;

    public class FakeEntity : Entity<Guid>
    {
        public FakeEntity(Guid id) : base(id)
        {
        }
    }
}
