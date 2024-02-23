using SubscriptionScreen.API.Entities.Enums;

namespace SubscriptionScreen.API.Controllers.Request
{
    public class SubscriptionRequestDTO
    {
        public string Name { get; set; } = "";
        public SubscriptionTypeEnum SubscriptionType { get; set; } 
    }
}