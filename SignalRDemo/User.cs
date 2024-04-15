namespace SignalRDemo
{
    public class User
    {
        private List<User> Subscriptions { get; set; }

        private List<User> Followers { get; set; }

        public string UserName { get; set; }

        public string KPI { get; set; }

        public void SubscribeToUser(User user)
        {
            Subscriptions.Add(user);
            user.AddFollower(this);
        }

        private void AddFollower(User user)
        {
            Followers.Add(user);
        }
    }
}
