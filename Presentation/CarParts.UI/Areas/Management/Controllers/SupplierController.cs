using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarParts.UI.Areas.Management.Controllers
{
    [Authorize(Roles = "Supplier")]

    public class SupplierController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
