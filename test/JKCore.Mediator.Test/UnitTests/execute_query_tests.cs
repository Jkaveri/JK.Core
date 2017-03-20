

namespace JKCore.Mediator.Test.UnitTests
{
    using Xunit;
    using System.Threading.Tasks;
    using JKCore.Mediator.Test.Queries;
    using JKCore.Mediator.Test.Shared;
    using System.Collections.Generic;
    using FluentAssertions;

    public class execute_query_tests : IClassFixture<MediatorFixture>
    {
        private readonly IMediator _mediator;

        public execute_query_tests(MediatorFixture mediator)
        {
            _mediator = mediator.Mediator;
        }

        [Fact]
        public async Task execute_query_should_successAsync()
        {
            // Arranges
            var query = new SampleListQuery();

            // Actions

            List<int> result = await _mediator.Execute(query);

            // Assertions

            result.Should().NotBeNullOrEmpty();
        }
    }
}
