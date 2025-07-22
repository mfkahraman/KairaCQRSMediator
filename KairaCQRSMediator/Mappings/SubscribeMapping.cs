using AutoMapper;
using KairaCQRSMediator.DataAccess.Entities;
using KairaCQRSMediator.Features.CQRS.Commands.SubscribeCommands;
using KairaCQRSMediator.Features.CQRS.Results.SubscribeResults;

namespace KairaCQRSMediator.Mappings
{
    public class SubscribeMapping : Profile
    {
        public SubscribeMapping()
        {
            CreateMap<Subscribe, CreateSubscribeCommand>().ReverseMap();
            CreateMap<Subscribe, GetSubscribesQueryResult>().ReverseMap();
        }
    }
}
