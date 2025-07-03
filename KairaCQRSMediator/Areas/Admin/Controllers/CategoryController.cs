using KairaCQRSMediator.Features.CQRS.Commands.CategoryCommands;
using KairaCQRSMediator.Features.CQRS.Handlers.CategoryHandlers;
using KairaCQRSMediator.Features.CQRS.Queries.CategoryQueries;
using Microsoft.AspNetCore.Mvc;

namespace KairaCQRSMediator.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController(GetCategoryQueryHandler getCategoryQueryHandler,
                                    GetCategoryByIdQueryHandler byIdQueryHandler,
                                    CreateCategoryCommandHandler createHandler,
                                    RemoveCategoryCommandHandler removeHandler,
                                    UpdateCategoryCommandHandler updateHandler
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
            if (!ModelState.IsValid)
            {
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
            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryCommand command)
        {
            await updateHandler.Handle(command);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteCategory(int id)
        {
            await removeHandler.Handle(new RemoveCategoryCommand(id));
            return RedirectToAction("Index");
        }
    }
}
