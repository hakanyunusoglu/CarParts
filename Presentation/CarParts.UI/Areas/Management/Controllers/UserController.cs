using CarParts.UI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarParts.UI.Areas.Management.Controllers
{
    [Area("Management")]
    public class UserController : Controller
    {
        UserModel model = new UserModel();
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult LockedScreen()
        {
            return View();
        }
        public IActionResult SignIn()
        {
            return View();
        }
        public IActionResult SignOut()
        {

            return View();
        }
        public IActionResult SignUp()
        {
           
            
            return View(model.Users);
        }
        public IActionResult ForgotPassword()
        {
            return View();
        }
    }
}
