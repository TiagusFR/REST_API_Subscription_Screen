namespace SubscriptionScreen.API.Controllers.Request
{
    public class UserRequestDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Document { get; set; }
        public DateTime Birthday { get; set; }
        public string Password { get; set; }

    }
}
