using AutoMapper;
using KairaCQRSMediator.DataAccess.Entities;
using KairaCQRSMediator.Features.CQRS.Handlers.CategoryHandlers;
using KairaCQRSMediator.Features.Mediator.Commands.ProductCommands;
using KairaCQRSMediator.Features.Mediator.Queries.ProductQueries;
using KairaCQRSMediator.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace KairaCQRSMediator.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController(IMediator mediator,
                                   GetCategoryQueryHandler categoryHandler,
                                   IMapper mapper,
                                   IImageService imageService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var product = await mediator.Send(new GetProductsQuery());
            return View(product);
        }

        public async Task<IActionResult> CreateProduct()
        {
            ViewBag.Categories = await GetCategories();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductCommand command)
        {

            if(command.ImageFile != null)
            {
                var imagePath = await imageService.SaveImageAsync(command.ImageFile, "products");
                command.ImageUrl = imagePath;
                ModelState.Remove("ImageUrl");
            }

            ViewBag.Categories = await GetCategories();

            //Fast Fail Yöntemi
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Lütfen tüm alanları doldurun");
                return View(command);
            }

            await mediator.Send(command);
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> UpdateProduct(int id)
        {
            ViewBag.Categories = await GetCategories();

            var product = await mediator.Send(new GetProductByIdQuery(id));
            var command = mapper.Map<UpdateProductComand>(product);
            return View(command);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductComand command)
        {
            if (command.ImageFile != null)
            {
                //Delete old image if exists
                if (!string.IsNullOrEmpty(command.ImageUrl))
                    await imageService.DeleteImageAsync(command.ImageUrl);

                var imagePath = await imageService.SaveImageAsync(command.ImageFile, "products");
                command.ImageUrl = imagePath;
                ModelState.Remove("ImageUrl");
            }

            ViewBag.Categories = await GetCategories();

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Lütfen tüm alanları doldurun");
                return View(command);
            }

            var result = await mediator.Send(command);
            if (!result)
            {
                ModelState.AddModelError("", "Ürün güncellenirken bir sorun oluştu");
                return View(command);
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await mediator.Send(new GetProductByIdQuery(id));
            if (product == null)
            {
                ModelState.AddModelError("", "Ürün bulunamadı");
                return RedirectToAction("Index");
            }

            //Delete image if exists
            if (!string.IsNullOrEmpty(product.ImageUrl))
                await imageService.DeleteImageAsync(product.ImageUrl);

            var result = await mediator.Send(new RemoveProductCommand(id));
            if (!result)
            {
                ModelState.AddModelError("", "Ürün silinirken bir sorun oluştu");
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        private async Task<List<SelectListItem>> GetCategories()
        {
            var categories = await categoryHandler.Handle();
            var list = (from x in categories
                        select new SelectListItem
                        {
                            Text = x.Name,
                            Value = x.Id.ToString()
                        }).ToList();
            return list;
        }



    }
}
