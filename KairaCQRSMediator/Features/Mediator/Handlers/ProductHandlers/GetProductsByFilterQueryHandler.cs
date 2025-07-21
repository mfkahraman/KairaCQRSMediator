using AutoMapper;
using KairaCQRSMediator.DataAccess.Entities;
using KairaCQRSMediator.Features.Mediator.Queries.ProductQueries;
using KairaCQRSMediator.Features.Mediator.Results.ProductResults;
using KairaCQRSMediator.Repositories;
using MediatR;

namespace KairaCQRSMediator.Features.Mediator.Handlers.ProductHandlers
{
    public class GetProductsByFilterQueryHandler(IRepository<Product> repository,
                                            IMapper mapper) 
        : IRequestHandler<GetProductsByFilterQuery, List<GetProductsQueryResult>>
    {

        public async Task<List<GetProductsQueryResult>> Handle(GetProductsByFilterQuery request, CancellationToken cancellationToken)
        {
            var products = await repository.GetProductsByFilterAsync(request.Filter);
            return mapper.Map<List<GetProductsQueryResult>>(products);
        }
    }

}
