namespace SignalRDemo
{
    public interface IMessageHubClient
    {
        Task SendOffersToUser(List<string> message);

        Task SendClientId(string clientId);
    }
}
