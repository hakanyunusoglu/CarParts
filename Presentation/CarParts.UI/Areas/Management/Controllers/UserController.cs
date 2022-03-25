using Microsoft.AspNetCore.Mvc;

namespace CarParts.UI.Areas.Management.Controllers
{
    [Area("Management")]
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult LockedScreen()
        {
            return View();
        }
    }
}
