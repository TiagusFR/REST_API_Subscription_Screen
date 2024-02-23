using SubscriptionScreen.API.Controllers.Request;
using SubscriptionScreen.API.Entities;

namespace SubscriptionScreen.API.Services
{
    public interface IUserService
    {
        User? GetById(Guid id);
        List<User> GetAll();
        User Add(User user);
        void Update(Guid id, UpdateUserRequestDTO request);
        void Delete(Guid id);
    }
}