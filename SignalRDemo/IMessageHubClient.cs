namespace SignalRDemo
{
    public interface IMessageHubClient
    {
        Task SendOffersToUser(List<string> messages);

        Task SendClientId(string clientId);
    }
}
