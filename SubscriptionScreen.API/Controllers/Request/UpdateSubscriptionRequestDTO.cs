using SubscriptionScreen.API.Entities.Enums;
using SubscriptionScreen.API.Entities;

namespace SubscriptionScreen.API.Controllers.Request
{
    public class UpdateSubscriptionRequestDTO
    {
        public string Name { get; set; }
        public SubscriptionTypeEnum SubscriptionType { get; set; } 
    }
}
