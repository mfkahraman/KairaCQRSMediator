using KairaCQRSMediator.Features.CQRS.Handlers.CategoryHandlers;
using Microsoft.AspNetCore.Mvc;

namespace KairaCQRSMediator.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly GetCategoryQueryHandler _getCategoryQueryHandler;

        public CategoryController(GetCategoryQueryHandler getCategoryQueryHandler)
        {
            _getCategoryQueryHandler = getCategoryQueryHandler;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var values = await _getCategoryQueryHandler.Handle();
            return View(values);
        }
    }
}
