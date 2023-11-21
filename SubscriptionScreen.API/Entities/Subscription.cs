namespace SubscriptionScreen.API.Entities
{
    public class Subscription
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string SubscriptionType { get; set; } //Troque isso para um tipo enum para ficar mais claro para quem for utilizar quais são os tipos que vc deseja
        public DateTime CreationDate { get; set; }
        public bool IsDeleted { get; set; } = false;
        public List<User> Users { get; set; } = new List<User>();
    }
}
