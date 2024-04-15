namespace SignalRDemo
{
    public class UserConnector : IUserConnector
    {
        private Dictionary<string, string> userConnections = new Dictionary<string, string>();

        public string GetConnectionForUser(string userName)
            => userConnections[userName];

        public void OnConnection(string userName, string connectionId) 
            => userConnections[userName] = connectionId;
    }
}
