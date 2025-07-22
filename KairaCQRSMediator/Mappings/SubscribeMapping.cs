using AutoMapper;
using KairaCQRSMediator.DataAccess.Entities;
using KairaCQRSMediator.Features.CQRS.Commands.SubscribeCommands;

namespace KairaCQRSMediator.Mappings
{
    public class SubscribeMapping : Profile
    {
        public SubscribeMapping()
        {
            CreateMap<Subscribe, CreateSubscribeCommand>().ReverseMap();
        }
    }
}
