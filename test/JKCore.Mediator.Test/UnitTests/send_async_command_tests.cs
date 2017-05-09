#region

using System.Threading.Tasks;
using FluentAssertions;
using JKCore.Mediator.Abstracts;
using JKCore.Mediator.Test.Messages;
using JKCore.Mediator.Test.Shared;
using Xunit;

#endregion

namespace JKCore.Mediator.Test.UnitTests
{
    public class send_async_command_tests : IClassFixture<MediatorFixture>
    {
        public send_async_command_tests(MediatorFixture mediatorFixture)
        {
            _mediator = mediatorFixture.Mediator;
        }

        private readonly IMediator _mediator;

        [Fact]
        public async Task send_command_should_successful()
        {
            // Arrange
            var command = new ExpectedResultMessage {ExpectedResult = "Henry"};

            // Actions
            var result = await _mediator.Send(command);

            // Assertions
            result.Successful.Should().BeTrue();
            result.Data.Should().Be(command.ExpectedResult);
            result.Errors.Should().BeEmpty();
        }

        [Fact]
        public async Task send_command_interface_should_success()
        {
            // arrange
            string expected = "henry";
            var command = new ExpectedMessage
            {
                Expected = expected
            };

            // Actions
            var result = await _mediator.Send(command);

            // Assertions
            result.Successful.Should().BeTrue();
            result.Data.Should().Be(expected);
        }

        [Fact]
        public async Task send_void_async_command_should_successful()
        {
            var executed = false;
            var command = new FakeMessage
            {
                Action = () => executed = true
            };

            // Actions
            var result = await _mediator.Send(command);

            // Assertions
            result.Successful.Should().BeTrue();
            executed.Should().BeTrue();
            result.Errors.Should().BeEmpty();
        }
    }


}