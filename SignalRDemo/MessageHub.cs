namespace SignalRDemo;

using Microsoft.AspNetCore.SignalR;

public class MessageHub(IUserConnector userConnector) : Hub<IMessageHubClient>
{
	public async Task SendOffersToUser(List<string> messages)
	{
		await Clients.All.SendOffersToUser(messages);
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