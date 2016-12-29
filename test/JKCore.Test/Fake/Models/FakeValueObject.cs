using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JKCore.Test.Fake
{
    using JKCore.Modeling;

    public class FakeValueObject:ValueObject<FakeValueObject>
    {
        public string StringValue { get; set; }
        public int IntValue { get; set; }
        public DateTime DateTimeValue { get; set; }
        public bool BooleanValue { get; set; }
    }
}
