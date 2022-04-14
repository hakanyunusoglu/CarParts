using CarParts.Domain.Entities;
using CarParts.UI.Models;
using CarsParts.Application.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CarParts.UI.Areas.WebUI.Controllers
{
    [Area("WebUI")]
    public class CartController : Controller
    {
        private readonly IRepository<Cart> repo;

        public CartController(IRepository<Cart> _repo)
        {
            repo = _repo;
        }

        public async Task<IActionResult> Index()
        {
            string username = User.FindFirst(ClaimTypes.Name).Value;
            Guid userID = new Guid(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var cart = await repo.GetByFilterAsync(x=>x.userID == userID);
            return View(new CartVM()
            {
                ID = cart.Id,
                userID = cart.userID,
                CreatedDate = cart.CreateDate,
                CartItemList = cart.CartItemList.Select(x => new CartItemModel()
                {
                    ID = x.Id,
                    productID = x.ProductID,
                    ImageUrl = x.Product.Image,
                    Name = x.Product.Name,
                    Quantity = x.Quantity,
                    CategoryName = x.Product.Category.Definition,
                    Price = x.Product.SellerLists.Select(x => x.Price).First()
                }).ToList()
            });
        }
    }
}
