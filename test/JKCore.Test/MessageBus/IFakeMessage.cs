namespace JKCore.MessageBus.Test
{
    public interface IFakeMessage {
        string Name { get; set; }
        int Age { get; set; }
    }
}