using JKCore.Repositories.EF.Test.Data;
using JKCore.Repositories.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace JKCore.Repositories.EF.Test.Helpers
{
    public class TestModelRepository : Repository<TestModel>
    {
        public TestModelRepository(DbContext dbcontext) : base(dbcontext)
        {
        }
    }
}
