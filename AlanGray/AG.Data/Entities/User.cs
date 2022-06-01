namespace AG.Data.Entities
{
    public class User
    {
        public string  Name { get; private set; }

        public string Follower { get; private set; }

        public User(string name, string follower)
        {
            Name = name;
            Follower = follower;
        }
    }
}
