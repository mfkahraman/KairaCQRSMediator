using KairaCQRSMediator.Features.Mediator.Queries.ProductQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KairaCQRSMediator.ViewComponents
{
    public class _HomepageBillboardComponent(IMediator mediator) : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var products = mediator.Send(new GetProductsQuery());
            return View(products);
        }
    }
}
