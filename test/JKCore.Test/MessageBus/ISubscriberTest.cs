namespace JKCore.Test.MessageBus
{
    #region

    using System;

    using FluentAssertions;

    using JKCore.MessageBus;

    using Moq;

    using Xunit;

    #endregion

    /// <summary>
    /// </summary>
    public class ISubscriberTest
    {
        /// <summary>
        /// </summary>
        [Fact]
        public void should_have_subscribe_method()
        {
            // Arranges
            var mock = new Mock<ISubscriber>();
            var key = "fake_msg";
            var expectedMsg = "henry fake msgs";
            var receivedMsg = "";
            Action<object> handler = (msg) => { receivedMsg = (string)msg; };
            mock.Setup(t => t.Subscribe(key, handler));

            // Actions
            handler(expectedMsg);

            // Assertions
            receivedMsg.Should().Be(expectedMsg);
        }
    }
}