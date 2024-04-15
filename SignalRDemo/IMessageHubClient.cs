namespace SignalRDemo
{
    public interface IMessageHubClient
    {
        Task SendOffersToUser(List<string> messages);

        Task SendStringToUser(dynamic obj);

        Task SendClientId(string clientId);
    }
}
