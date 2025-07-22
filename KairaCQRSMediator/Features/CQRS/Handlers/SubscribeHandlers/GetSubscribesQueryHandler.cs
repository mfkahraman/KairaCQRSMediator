using AutoMapper;
using KairaCQRSMediator.DataAccess.Entities;
using KairaCQRSMediator.Features.CQRS.Results.SubscribeResults;
using KairaCQRSMediator.Repositories;

namespace KairaCQRSMediator.Features.CQRS.Handlers.SubscribeHandlers
{
    public class GetSubscribesQueryHandler(IRepository<Subscribe> repository,
                                           IMapper mapper)
    {
        public async Task<List<GetSubscribesQueryResult>> Handle()
        {
            var subscribes = await repository.GetAllAsync();
            return mapper.Map<List<GetSubscribesQueryResult>>(subscribes);
        }
    }
}
