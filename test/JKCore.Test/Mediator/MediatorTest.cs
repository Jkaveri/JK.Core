namespace JKCore.Test.Mediator
{
    #region

    using FluentAssertions;

    using JK.Core.Mediator;
    using JK.Core.Mediator.Commands;

    using Moq;

    using Xunit;

    #endregion

    /// <summary>
    /// </summary>
    public class MediatorTest
    {
        /// <summary>
        /// </summary>
        [Fact]
        public void should_return_result_when_command_to_be_sent()
        {
            // Arranges
            var command = new FakeCommand();
            var mockCommandResolver = new Mock<ICommandHandlerResolver>();
            var mockListenerResolver = new Mock<IEventListenerResolver>();
            var mediator = new Mediator(mockCommandResolver.Object, mockListenerResolver.Object);
            var expectedResult = "fake result";

            mockCommandResolver.Setup(t => t.ResolveHandler<FakeCommand, object>())
                .Returns(new FakeCommandHandler(expectedResult));

            // Actions
            var result = mediator.Send<FakeCommand, object>(command);

            // Assertions
            result.Should().Be(expectedResult);
        }

        private class FakeCommand : ICommand<object>
        {
        }

        private class FakeCommandHandler:ICommandHandler<FakeCommand, object>
        {
            private readonly object _result;

            public FakeCommandHandler(object result)
            {
                _result = result;
            }

            /// <summary>
            /// </summary>
            /// <param name="command">
            /// The command.
            /// </param>
            /// <returns>
            /// </returns>
            public object Handle(FakeCommand command)
            {
                return this._result;
            }
        }
    }
}