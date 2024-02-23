namespace SubscriptionScreen.API.Entities
{
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = "";
        public string Email { get; set; } = "";
        public string Document { get; set; } = "";
        public DateTime Birthday { get; set; }
        public string Password { get; set; } = "";
        public bool IsDeleted { get; set; } = false;

    }
}