using Microsoft.AspNetCore.Mvc;

namespace CarParts.UI.Areas.WebUI.Controllers
{
    [Area("WebUI")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Blog()
        {
            return View();
        }
    }
}
