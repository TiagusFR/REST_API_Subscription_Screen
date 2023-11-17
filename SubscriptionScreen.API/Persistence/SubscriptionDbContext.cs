using SubscriptionScreen.API.Entities;

namespace SubscriptionScreen.API.Persistence
{
    public class SubscriptionDbContext
    {
        public List<Subscription> Subscriptions { get; set; }

        public SubscriptionDbContext()
        {
            Subscriptions = new List<Subscription>();
        }
    }

    
}
