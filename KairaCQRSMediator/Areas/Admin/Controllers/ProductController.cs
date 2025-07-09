using AutoMapper;
using KairaCQRSMediator.Features.CQRS.Handlers.CategoryHandlers;
using KairaCQRSMediator.Features.Mediator.Commands.ProductCommands;
using KairaCQRSMediator.Features.Mediator.Queries.ProductQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace KairaCQRSMediator.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController(IMediator mediator,
                                   GetCategoryQueryHandler categoryHandler,
                                   IMapper mapper) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var product = await mediator.Send(new GetProductsQuery());
            return View(product);
        }

        public async Task<IActionResult> CreateProduct()
        {
            var categories = await categoryHandler.Handle();
            ViewBag.Categories = (from x in categories
                                  select new SelectListItem
                                  {
                                      Text = x.Name,
                                      Value = x.Id.ToString()
                                  }).ToList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductCommand command)
        {
            await mediator.Send(command);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateProduct(int id)
        {
            var categories = await categoryHandler.Handle();
            ViewBag.Categories = (from x in categories
                                  select new SelectListItem
                                  {
                                      Text = x.Name,
                                      Value = x.Id.ToString()
                                  }).ToList();
            var product = await mediator.Send(new GetProductByIdQuery(id));
            var command = mapper.Map<UpdateProductComand>(product);
            return View(command);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductComand command)
        {
            var result = await mediator.Send(command);
            if (!result)
            {
                ModelState.AddModelError("", "Ürün güncellenirken bir sorun oluştu");
                return View(command);
            }
            return RedirectToAction("Index");
        }




    }
}
