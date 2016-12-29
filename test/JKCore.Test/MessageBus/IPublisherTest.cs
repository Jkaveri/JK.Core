namespace JKCore.MessageBus.Test
{
    using FluentAssertions;
    using Moq;
    using Xunit;

    public class IPublisherTest
    {
        [Fact]
        public void should_have_publish_method()
        {
            // Arranges
            var mock = new Mock<IPublisher>();
            var msg = "msg";
            var key = "fake_message";
            var executed = false;
            mock.Setup(t => t.Publish(key, msg)).Callback(()=>
            {
                executed = true;
            });
            
            // Actions
            mock.Object.Publish(key, msg);

            // Assertions
            executed.Should().BeTrue();
        }

        [Fact]
        public void should_have_publish_T_method()
        {
            // Arranges
            var mock = new Mock<IPublisher>();
            var msg = new
            {
                Name = "Henry",
                Age = 12
            };
            var executed = false;
            mock.Setup(t => t.Publish<IFakeMessage>(msg)).Callback(() =>
            {
                executed = true;
            });

            // Actions
            mock.Object.Publish<IFakeMessage>(msg);

            // Assertions
            executed.Should().BeTrue();
        }
    }
}
