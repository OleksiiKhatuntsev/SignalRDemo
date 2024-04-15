namespace SignalRDemo
{
    public class UserConnector : IUserConnector
    {
        private readonly Dictionary<string, string> userConnections = [];

        public string GetConnectionForUser(string userName)
            => userConnections[userName];

        public void OnConnection(string userName, string connectionId)
            => userConnections[userName] = connectionId;
    }
}
