using AutoMapper;
using KairaCQRSMediator.Features.CQRS.Commands.CategoryCommands;
using KairaCQRSMediator.Features.CQRS.Handlers.CategoryHandlers;
using KairaCQRSMediator.Features.CQRS.Queries.CategoryQueries;
using KairaCQRSMediator.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace KairaCQRSMediator.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController(GetCategoryQueryHandler getCategoryQueryHandler,
                                    GetCategoryByIdQueryHandler byIdQueryHandler,
                                    CreateCategoryCommandHandler createHandler,
                                    RemoveCategoryCommandHandler removeHandler,
                                    UpdateCategoryCommandHandler updateHandler,
                                    IImageService imageService,
                                    IMapper mapper
                                    ) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var values = await getCategoryQueryHandler.Handle();
            return View(values);
        }

        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryCommand command)
        {
            if (command.ImageFile != null)
            {
                var imagePath = await imageService.SaveImageAsync(command.ImageFile, "categories");
                command.ImageUrl = imagePath;
                ModelState.Remove("ImageUrl");
            }

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Lütfen tüm alanları doldurun");
                return View(command);
            }

            await createHandler.Handle(command);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateCategory(int id)
        {
            var category = await byIdQueryHandler.Handle(new GetCategoryByIdQuery(id));
            if (category == null)
            {
                return NotFound();
            }
            var dto = mapper.Map<UpdateCategoryCommand>(category);
            return View(dto);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryCommand command)
        {
            if (command.ImageFile != null)
            {
                //Delete old image if exists
                if (!string.IsNullOrEmpty(command.ImageUrl))
                    await imageService.DeleteImageAsync(command.ImageUrl);

                var imagePath = await imageService.SaveImageAsync(command.ImageFile, "categories");
                command.ImageUrl = imagePath;
                ModelState.Remove("ImageUrl");
            }

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Lütfen tüm alanları doldurun");
                return View(command);
            }

            await updateHandler.Handle(command);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await byIdQueryHandler.Handle(new GetCategoryByIdQuery(id));
            if (category == null)
            {
                ModelState.AddModelError("", "Kategori bulunamadı");
                return RedirectToAction("Index");
            }

            //Delete image if exists
            if (!string.IsNullOrEmpty(category.ImageUrl))
                await imageService.DeleteImageAsync(category.ImageUrl);

            await removeHandler.Handle(new RemoveCategoryCommand(id));
            return RedirectToAction("Index");
        }
    }
}
