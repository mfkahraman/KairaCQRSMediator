using Microsoft.AspNetCore.Mvc;

namespace KairaCQRSMediator.Controllers
{
    public class MainController : Controller
    {
        public IActionResult Homepage()
        {
            return View();
        }

    }
}
