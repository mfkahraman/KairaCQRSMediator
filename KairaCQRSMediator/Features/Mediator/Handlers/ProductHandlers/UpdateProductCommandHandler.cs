using AutoMapper;
using KairaCQRSMediator.DataAccess.Entities;
using KairaCQRSMediator.Features.Mediator.Commands.ProductCommands;
using KairaCQRSMediator.Repositories;
using MediatR;

namespace KairaCQRSMediator.Features.Mediator.Handlers.ProductHandlers
{
    public class UpdateProductCommandHandler(IRepository<Product> repository,
                                             IMapper mapper)
        : IRequestHandler<UpdateProductComand, bool>
    {
        public async Task<bool> Handle(UpdateProductComand request, CancellationToken cancellationToken)
        {
            var product = mapper.Map<Product>(request);
            try
            {
                await repository.UpdateAsync(product);
            }
            catch (Exception)
            {

                return false;
            }
            
            return true;
        }
    }
}
