namespace JKCore.Mediator.Test.UnitTests
{
    #region

    using System.Threading.Tasks;

    using FluentAssertions;

    using JKCore.Mediator.Test.Commands;
    using JKCore.Mediator.Test.Shared;

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
            var command = new ExpectedResultAsyncCommand() { ExpectedResult = "Henry" };

            // Actions
            var result = await this._mediator.SendAsync(command);

            // Assertions
            result.Should().Be(command.ExpectedResult);
        }
    }
}