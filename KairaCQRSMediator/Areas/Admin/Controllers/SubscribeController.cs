using KairaCQRSMediator.Features.CQRS.Handlers.SubscribeHandlers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace KairaCQRSMediator.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SubscribeController(GetSubscribesQueryHandler getHandler,
                                     RemoveSubscribeCommandHandler removeHandler) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var subscribes = await getHandler.Handle();
            return View(subscribes);
        }

        public async Task<IActionResult> DeleteSubscribe(int id)
        {
            var result = await removeHandler.HandleAsync(id);
            return RedirectToAction("Index");
        }
    }
}
