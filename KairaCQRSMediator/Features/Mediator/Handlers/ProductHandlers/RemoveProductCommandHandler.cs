using KairaCQRSMediator.DataAccess.Entities;
using KairaCQRSMediator.Features.Mediator.Commands.ProductCommands;
using KairaCQRSMediator.Repositories;
using MediatR;

namespace KairaCQRSMediator.Features.Mediator.Handlers.ProductHandlers
{
    public class RemoveProductCommandHandler(IRepository<Product> repository) : IRequestHandler<RemoveProductCommand, bool>
    {
        public async Task<bool> Handle(RemoveProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await repository.DeleteAsync(request.Id);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}
