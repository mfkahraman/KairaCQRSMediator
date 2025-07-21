using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KairaCQRSMediator.ViewComponents
{
    public class _HomepageBestSellersComponent(IMediator mediator) : ViewComponent
    {
        public IViewComponentResult InvokeAsync()
        {
            var bestSellers = mediator.Send(new GetProduc)
            return View();
        }
    }
}
