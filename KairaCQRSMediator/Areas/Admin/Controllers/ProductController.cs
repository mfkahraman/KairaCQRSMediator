using KairaCQRSMediator.Features.Mediator.Queries.ProductQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KairaCQRSMediator.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController(IMediator mediator) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var product = await mediator.Send(new GetProductsQuery());
            return View(product);
        }
    }
}
