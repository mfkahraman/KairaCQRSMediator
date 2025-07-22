using KairaCQRSMediator.DataAccess.Entities;
using KairaCQRSMediator.Repositories;

namespace KairaCQRSMediator.Features.CQRS.Handlers.SubscribeHandlers
{
    public class RemoveSubscribeCommandHandler(IRepository<Subscribe> repository)
    {
        public async Task<bool> HandleAsync(int id)
        {
            try
            {
                await repository.DeleteAsync(id);

            }
            catch (Exception)
            {

                return false;
            }
            return true;
        }
    }
}
