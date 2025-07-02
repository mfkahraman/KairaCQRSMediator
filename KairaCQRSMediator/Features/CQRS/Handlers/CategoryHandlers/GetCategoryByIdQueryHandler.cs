using KairaCQRSMediator.DataAccess.Entities;
using KairaCQRSMediator.Features.CQRS.Queries.CategoryQueries;
using KairaCQRSMediator.Features.CQRS.Results.CategoryResults;
using KairaCQRSMediator.Repositories;

namespace KairaCQRSMediator.Features.CQRS.Handlers.CategoryHandlers
{
    public class GetCategoryByIdQueryHandler
    {
        private readonly IRepository<Category> _repository;

        public GetCategoryByIdQueryHandler(IRepository<Category> repository)
        {
            _repository = repository;
        }

        public async Task<GetCategoryByIdQueryResult> Handle(GetCategoryByIdQuery query)
        {
            var category = await _repository.GetByIdAsync(query.Id);
            var dto = new GetCategoryByIdQueryResult
            {
                Id = category.Id,
                Name = category.Name,
                ImageUrl = category.ImageUrl,
                Products = category.Products
            };
            return dto;
        }
    }
}
