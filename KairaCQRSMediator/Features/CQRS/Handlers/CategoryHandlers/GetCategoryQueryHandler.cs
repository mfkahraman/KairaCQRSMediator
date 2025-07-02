using KairaCQRSMediator.DataAccess.Entities;
using KairaCQRSMediator.Features.CQRS.Results.CategoryResults;
using KairaCQRSMediator.Repositories;

namespace KairaCQRSMediator.Features.CQRS.Handlers.CategoryHandlers
{
    public class GetCategoryQueryHandler
    {
        private readonly IRepository<Category> _repository;

        public GetCategoryQueryHandler(IRepository<Category> repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<List<GetCategoryQueryResult>> Handle()
        {
            var categories = await _repository.GetAllAsync();

            var dtos = categories.Select(c => new GetCategoryQueryResult
            {
                Id = c.Id,
                Name = c.Name,
                ImageUrl = c.ImageUrl,
                Products = c.Products
            }).ToList();

            return dtos;
        }
    }
}
