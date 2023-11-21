using AutoMapper;
using SubscriptionScreen.API.Controllers.Request;
using SubscriptionScreen.API.Entities;

namespace SubscriptionScreen.API.Controllers.AutoMapper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<SubscriptionRequestDTO, Subscription>();
        }
    }
}
