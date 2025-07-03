using KairaCQRSMediator.DataAccess.Entities;
using KairaCQRSMediator.Features.CQRS.Commands.CategoryCommands;
using KairaCQRSMediator.Repositories;

namespace KairaCQRSMediator.Features.CQRS.Handlers.CategoryHandlers
{
    public class UpdateCategoryCommandHandler(IRepository<Category> repository)
    {
        public async Task Handle(UpdateCategoryCommand command)
        {
            await repository.UpdateAsync(new Category
            {
                Id = command.Id,
                Name = command.Name,
                ImageUrl = command.ImageUrl
            });
        }
    }
}
