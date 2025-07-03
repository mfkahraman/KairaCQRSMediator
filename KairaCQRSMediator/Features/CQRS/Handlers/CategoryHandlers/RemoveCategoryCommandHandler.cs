using KairaCQRSMediator.DataAccess.Entities;
using KairaCQRSMediator.Features.CQRS.Commands.CategoryCommands;
using KairaCQRSMediator.Repositories;

namespace KairaCQRSMediator.Features.CQRS.Handlers.CategoryHandlers
{
    public class RemoveCategoryCommandHandler(IRepository<Category> repository)
    {

        public async Task Handle(RemoveCategoryCommand command)
        {
            await repository.DeleteAsync(command.Id);
        }
    }
}
