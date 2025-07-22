using KairaCQRSMediator.Features.Mediator.Queries.ProductQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KairaCQRSMediator.ViewComponents
{
    public class _HomepageRelatedProductsComponent(IMediator mediator) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var ids = new List<int> { 12, 1, 2, 10 };
            var products = await mediator.Send(new GetProductsByFilterQuery(p=> ids.Contains(p.Id)));
            return View(products);
        }
    }
}
