using System;
using System.Collections.Generic;
using System.Linq;
using SubscriptionScreen.API.Controllers.Request;
using SubscriptionScreen.API.Entities;
using SubscriptionScreen.API.Persistence;

namespace SubscriptionScreen.API.Services
{
    public class SubscriptionService : ISubscriptionService
    {
        private readonly DatabaseContext _context;

        public SubscriptionService(DatabaseContext context)
        {
            _context = context;
        }

        public Subscription? GetById(Guid id)
        {
            return _context.Subscriptions.SingleOrDefault(x => x.Id == id);
        }

        public List<Subscription> GetAll()
        {
            return _context.Subscriptions.Where(x => !x.IsDeleted).ToList();
        }

        public Subscription Add(Subscription subscription)
        {
            _context.Subscriptions.Add(subscription);
            return subscription;
        }

        public void Update(Guid id, UpdateSubscriptionRequestDTO request)
        {
            Subscription? subscriptionFound = GetById(id);

            if (subscriptionFound == null)
            {
                throw new ArgumentException($"Cannot find the Subscription with the Id: {id}");
            }

            subscriptionFound.Name = request.Name;
            subscriptionFound.SubscriptionType = request.SubscriptionType;
        }

        public void Delete(Guid id)
        {
            Subscription? subscription = GetById(id);

            if (subscription == null)
            {
                throw new ArgumentException($"Cannot find the Subscription with the Id: {id}");
            }

            subscription.IsDeleted = true;
            _context.Subscriptions.Remove(subscription);
        }
    }
}
