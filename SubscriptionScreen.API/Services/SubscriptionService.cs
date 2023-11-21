using SubscriptionScreen.API.Entities;
using SubscriptionScreen.API.Persistence;

namespace SubscriptionScreen.API.Services
{
    public class SubscriptionService
    {
        private readonly SubscriptionDbContext _context;

        public SubscriptionService(SubscriptionDbContext context)
        {
            _context = context;
        }

        //O interrogação ao lado do objeto Subscription indica para quem for consumir esse metodo que o retorno pode ser null, afinal aqui vc utiliza SingleOrDefault
        public Subscription? GetById(Guid id)
        {
            return _context.Subscriptions.SingleOrDefault(x => x.Id == id);
        }

        public List<Subscription> GetAll()
        {
            return _context.Subscriptions.Where(x => !x.IsDeleted).ToList();
        }

        public void Add(Subscription subscription)
        {
            _context.Subscriptions.Add(subscription);
        }

        public void Update(Guid id, Subscription input)
        {
            Subscription? subscriptionFounded = GetById(id);

            if (subscriptionFounded == null)
            {
                throw new ArgumentException($"Cannot found the Subscription with the Id: {id}");
            }

            subscriptionFounded.Name = input.Name;
            subscriptionFounded.SubscriptionType = input.SubscriptionType;
            subscriptionFounded.CreationDate = input.CreationDate;
        }

        public void Delete(Guid id)
        {
            Subscription? subscription = GetById(id);

            if (subscription == null)
            {
                throw new ArgumentException($"Cannot found the Subscription with the Id: {id}");
            }

            subscription.IsDeleted = true;
            _context.Subscriptions.Remove(subscription);
        }
    }
}