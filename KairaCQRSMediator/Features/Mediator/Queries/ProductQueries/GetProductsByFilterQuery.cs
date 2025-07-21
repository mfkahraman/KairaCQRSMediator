using KairaCQRSMediator.DataAccess.Entities;
using KairaCQRSMediator.Features.Mediator.Results.ProductResults;
using MediatR;
using System.Linq.Expressions;

namespace KairaCQRSMediator.Features.Mediator.Queries.ProductQueries
{
    public class GetProductsByFilterQuery : IRequest<List<GetProductsQueryResult>>
    {
        public Expression<Func<Product, bool>> Filter { get; }

        public GetProductsByFilterQuery(Expression<Func<Product, bool>> filter)
        {
            Filter = filter;
        }
    }
}
