using KairaCQRSMediator.Features.CQRS.Commands.SubscribeCommands;
using KairaCQRSMediator.Features.CQRS.Handlers.SubscribeHandlers;
using Microsoft.AspNetCore.Mvc;

namespace KairaCQRSMediator.Controllers
{
    public class MainController(CreateSubscribeCommandHandler handler) : Controller
    {
        public IActionResult Homepage()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateSubscribe(CreateSubscribeCommand command)
        {

            var result = await handler.Handle(command);
            return Json(new { success = true, message = "Kiralama talebiniz başarıyla oluşturuldu!" });
        }
    }
}
