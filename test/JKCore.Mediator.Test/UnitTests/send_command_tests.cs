using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JKCore.Mediator.Test.UnitTests
{
    using FluentAssertions;

    using JKCore.Mediator.Test.Commands;
    using JKCore.Mediator.Test.Shared;

    using Xunit;

    public class send_command_tests : IClassFixture<MediatorFixture>
    {
        private readonly MediatorFixture _fixture;

        private readonly IMediator _mediator;

        public send_command_tests(MediatorFixture mediatorFixture)
        {
            this._fixture = mediatorFixture;
            this._mediator = this._fixture.Mediator;
        }
        [Fact]
        public void send_command_should_successful()
        {
            // Arrange
            var command = new ExpectedResultCommand
                              {
                                  ExpectedResult = "Henry"
                              };
            
            // Actions
            var result = this._mediator.Send(command);

            // Assertions
            result.Succeed.Should().BeTrue();
            result.Result.Should().Be(command.ExpectedResult);
            result.Errors.Should().BeEmpty();
        }
    }
}
