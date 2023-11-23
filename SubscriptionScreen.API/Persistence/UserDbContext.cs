using SubscriptionScreen.API.Entities;

namespace SubscriptionScreen.API.Persistence
{
    public class UserDbContext
    {
        public List<User> Users { get; set; }

        public UserDbContext()
        {
            Users = new List<User>();
        }
    }


}
