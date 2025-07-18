using KairaCQRSMediator.Features.Mediator.Queries.ProductQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KairaCQRSMediator.ViewComponents
{
    public class _HomepageNewArrivalComponent(IMediator mediator) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var lastFourProducts = (await mediator.Send(new GetProductsQuery()))
                .OrderByDescending(p => p.Id)
                .Take(4)
                .ToList();
            return View(lastFourProducts);
        }
    }
}
