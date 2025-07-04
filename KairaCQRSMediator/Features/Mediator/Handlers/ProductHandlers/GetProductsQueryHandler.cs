using AutoMapper;
using KairaCQRSMediator.DataAccess.Entities;
using KairaCQRSMediator.Features.Mediator.Queries.ProductQueries;
using KairaCQRSMediator.Features.Mediator.Results.ProductResults;
using KairaCQRSMediator.Repositories;
using MediatR;

namespace KairaCQRSMediator.Features.Mediator.Handlers.ProductHandlers
{
    public class GetProductsQueryHandler(IRepository<Product> repository,
                                         IMapper mapper) 
        : IRequestHandler<GetProductsQuery, List<GetProductsQueryResult>>
    {
        public async Task<List<GetProductsQueryResult>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var prodcuts = await repository.GetAllAsync();
            return mapper.Map<List<GetProductsQueryResult>>(prodcuts);
        }
    }
}
