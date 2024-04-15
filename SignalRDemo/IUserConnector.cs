namespace SignalRDemo
{
    public interface IUserConnector
    {
        void OnConnection(string userName, string connectionId);

        string GetConnectionForUser(string userName);
    }
}
