using SubscriptionScreen.API.Entities.Enums;

namespace SubscriptionScreen.API.Entities
{
    public class Subscription
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public SubscriptionTypeEnum SubscriptionType { get; set; } = SubscriptionTypeEnum.Standard;
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public bool IsDeleted { get; set; } = false;
        public List<User> Users { get; set; } = new List<User>();
    }
}
