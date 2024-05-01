namespace SignalRDemo;

using Microsoft.AspNetCore.SignalR;

public class MessageHub(IUserConnector userConnector) : Hub<IMessageHubClient>
{
    public async Task SendOffersToUser()
	{
		await Clients.All.SendOffersToUser(new List<string> {"123"});
	}

	public async Task SendOffersToExactUser(string connectionId, List<string> messages)
		=> await Clients.Client(connectionId).SendOffersToUser(messages);

	public async Task GetClientId()
		=> await Clients.Caller.SendClientId(Context.ConnectionId);

	public async Task SetClientConnectionPair(string userName)
	{
		userConnector.OnConnection(userName, Context.ConnectionId);
		await Clients.Caller.SendClientId(Context.ConnectionId + userName);
    }
}