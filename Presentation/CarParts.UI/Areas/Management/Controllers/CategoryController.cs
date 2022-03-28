using Microsoft.AspNetCore.Mvc;

namespace CarParts.UI.Areas.Management.Controllers
{
    [Area("Management")]
    public class CategoryController : Controller
    {
        public IActionResult ListCategory()
        {
            return View();
        }
        public IActionResult NewCategory()
        {
            return View();
        }
        public IActionResult UpdateCategory()
        {
            return View();
        }
        public IActionResult DeleteCategory()
        {
            return View();
        }
    }
}
