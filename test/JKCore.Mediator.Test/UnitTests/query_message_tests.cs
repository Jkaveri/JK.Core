using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using JKCore.Mediator.Abstracts;
using JKCore.Mediator.Test.Messages;
using JKCore.Mediator.Test.Shared;
using Xunit;

namespace JKCore.Mediator.Test.UnitTests
{
    public class query_message_tests : IClassFixture<MediatorFixture>
    {
        private IMediator _mediator;

        public query_message_tests(MediatorFixture fixture)
        {
            _mediator = fixture.Mediator;
        }

        [Fact]
        public async Task send_query_class_should_success()
        {
            // Arrange
            int expectedInt = 1;
            var msg = new QueryMessage
            {
                ExpectedInt = expectedInt
            };


            // Actions
            var result = await _mediator.Send(msg);

            // Assertions
            result.Successful.Should().BeTrue();
            result.Data.Should().Be(expectedInt);
        }

        [Fact]
        public async Task send_query_interface_should_success()
        {
            // Arrange
            int expectedInt = 1;

            var msg = new QueryInterfaceMessage
            {
                ExpectedInt = expectedInt
            };

            // Actions
            var result = await _mediator.Send(msg);


            // Assertions
            result.Successful.Should().BeTrue();
            result.Data.Should().Be(expectedInt);
        }
    }
}
