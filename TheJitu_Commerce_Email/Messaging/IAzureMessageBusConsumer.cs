namespace TheJitu_Commerce_Email.Messaging
{
    public interface IAzureMessageBusConsumer
    {
        Task Start();
        Task Stop();
    }
}
