namespace SignalRDemo
{
    public interface IMessageHubClient
    {
        Task SendOffersToUser(List<string> messages);

        Task SendStringToUser(string message);

        Task SendClientId(string clientId);
    }
}
