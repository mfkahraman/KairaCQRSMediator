using AutoMapper;
using KairaCQRSMediator.DataAccess.Entities;
using KairaCQRSMediator.Features.Mediator.Queries.ProductQueries;
using KairaCQRSMediator.Features.Mediator.Results.ProductResults;
using KairaCQRSMediator.Repositories;
using MediatR;
using NuGet.Protocol.Plugins;

namespace KairaCQRSMediator.Features.Mediator.Handlers.ProductHandlers
{
    public class GetProductByIdQueryHandler(IRepository<Product> repository,
                                            IMapper mapper)
        : IRequestHandler<GetProductByIdQuery, GetProductByIdQueryResult>
    {
        public async Task<GetProductByIdQueryResult> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await repository.GetByIdAsync(request.Id);
            return mapper.Map<GetProductByIdQueryResult>(product);
        }
    }
}
