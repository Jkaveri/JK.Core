using JKCore.Mediator.Queries;
using JKCore.Mediator.Test.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JKCore.Mediator.Test.QueryProcessors
{
    public class SampleListProcessor : IQueryProcessor<SampleListQuery, List<int>>
    {
        
        public Task<List<int>> Execute(SampleListQuery query)
        {
            return Task.FromResult(new List<int>() { 1, 2, 3 });
        }
    }
}
