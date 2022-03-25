using Microsoft.AspNetCore.Mvc;

namespace CarParts.UI.Areas.Management.Controllers
{
    [Area("Management")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
