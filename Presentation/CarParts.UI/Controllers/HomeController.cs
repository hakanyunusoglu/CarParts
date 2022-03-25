using Microsoft.AspNetCore.Mvc;

namespace CarParts.UI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
