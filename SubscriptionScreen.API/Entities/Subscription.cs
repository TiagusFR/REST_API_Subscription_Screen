namespace SubscriptionScreen.API.Entities
{
    public class Subscription
    {
        public Subscription()
        {
            Users = new List<User>();
            IsDeleted = false;
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string SubscriptionType { get; set; }
        public DateTime CreationDate { get; set; }
        public bool IsDeleted { get; set; }
        public List<User> Users { get; set; }

        public void Update(string name, string subscriptionType, DateTime creationDate)
        {
            Name = name;
            SubscriptionType = subscriptionType;
            CreationDate = creationDate;
        }

        public void Delete() 
        {
            IsDeleted = true;
        }
    }
}
