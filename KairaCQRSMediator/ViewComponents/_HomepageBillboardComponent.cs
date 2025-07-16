using KairaCQRSMediator.Features.CQRS.Handlers.CategoryHandlers;
using KairaCQRSMediator.Features.Mediator.Queries.ProductQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace KairaCQRSMediator.ViewComponents
{
    public class _HomepageBillboardComponent(GetCategoryQueryHandler categoryHandler) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = (await categoryHandler.Handle()).Take(3).ToList();
            return View(categories);
        }
    }
}
