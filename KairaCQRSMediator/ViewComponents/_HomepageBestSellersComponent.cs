using KairaCQRSMediator.DataAccess.Entities;
using KairaCQRSMediator.Features.Mediator.Queries.ProductQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace KairaCQRSMediator.ViewComponents
{
    public class _HomepageBestSellersComponent(IMediator mediator) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<int> ids = new() {13, 9, 8, 11};

            var bestSellers = await mediator.Send(new GetProductsByFilterQuery(p => ids.Contains(p.Id)));

            return View(bestSellers);
        }
    }
}
