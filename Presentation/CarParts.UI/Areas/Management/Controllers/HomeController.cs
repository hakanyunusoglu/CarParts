using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarParts.UI.Areas.Management.Controllers
{

    [Area("Management")]
    public class HomeController : Controller
    {
        [Authorize(Roles ="Admin,Seller,User")]//SıgnInsayfası yonlendırmesı ıcın
        public IActionResult Index()
        {
            return View();
        }
        [Authorize(Roles ="Admin")]
        public IActionResult AdminPage()
        {
            return View();
        }
        [Authorize(Roles = "User")]
        public IActionResult UserPage()
        {
            return View();
        }
        [Authorize(Roles = "Seller")]
        public IActionResult SellerPage()
        {
            return View();
        }

    }
}
