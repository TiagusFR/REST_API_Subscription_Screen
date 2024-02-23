using System;
using System.Collections.Generic;
using SubscriptionScreen.API.Controllers.Request;
using SubscriptionScreen.API.Entities;

namespace SubscriptionScreen.API.Services
{
    public interface ISubscriptionService
    {
        Subscription? GetById(Guid id);
        List<Subscription> GetAll();
        Subscription Add(Subscription subscription);
        void Update(Guid id, UpdateSubscriptionRequestDTO request);
        void Delete(Guid id);
    }
}
