namespace JKCore.Mediator.Test.UnitTests
{
    #region

    using FluentAssertions;
    using JKCore.Mediator.Commands;
    using JKCore.Mediator.Test.Commands;
    using JKCore.Mediator.Test.Shared;
    using System.Threading.Tasks;
    using Xunit;

    #endregion

    public class send_async_command_tests : IClassFixture<MediatorFixture>
    {
        private readonly MediatorFixture _fixture;

        private readonly IMediator _mediator;

        public send_async_command_tests(MediatorFixture mediatorFixture)
        {
            this._fixture = mediatorFixture;
            this._mediator = this._fixture.Mediator;
        }

        [Fact]
        public async Task send_command_should_successful()
        {
            // Arrange
            var command = new ExpectedResultAsyncCommand { ExpectedResult = "Henry" };

            // Actions
            var result = await this._mediator.SendAsync(command);

            // Assertions
            result.Succeed.Should().BeTrue();
            result.Data.Should().Be(command.ExpectedResult);
            result.Errors.Should().BeEmpty();
        }

        [Fact]
        public async Task send_void_async_command_should_successful()
        {
            bool executed = false;
            var command = new VoidAsyncCommand
            {
                Action = () => executed = true
            };

            // Actions
            ICommandResult result = await _mediator.SendAsync(command);

            // Assertions
            result.Succeed.Should().BeTrue();
            executed.Should().BeTrue();
            result.Errors.Should().BeEmpty();
        }

        public void send_void_command_should_successful()
        {

            bool executed = false;
            var command = new VoidCommand
            {
                Action = () => executed = true
            };

            // Actions
            ICommandResult result = _mediator.Send(command);

            // Assertions
            result.Succeed.Should().BeTrue();
            executed.Should().BeTrue();
            result.Errors.Should().BeEmpty();
        }
    }
}