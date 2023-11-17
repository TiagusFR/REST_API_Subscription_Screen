namespace SubscriptionScreen.API.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Document { get; set; }
        public DateTime Birthday { get; set; }
        public string Password { get; set; }

    }
}