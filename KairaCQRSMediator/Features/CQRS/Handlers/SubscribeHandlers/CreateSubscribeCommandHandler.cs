using AutoMapper;
using KairaCQRSMediator.DataAccess.Entities;
using KairaCQRSMediator.Features.CQRS.Commands.SubscribeCommands;
using KairaCQRSMediator.Repositories;

namespace KairaCQRSMediator.Features.CQRS.Handlers.SubscribeHandlers
{
    public class CreateSubscribeCommandHandler(IRepository<Subscribe> repository,
                                               IMapper mapper)
    {
        public async Task<bool> Handle(CreateSubscribeCommand command)
        {
            var subscribe = mapper.Map<Subscribe>(command);
            subscribe.IsActive = true;
            try
            {
                await repository.CreateAsync(subscribe);
            }
            catch (Exception)
            {

                return false;
            }
            return true;
        }
    }
}
