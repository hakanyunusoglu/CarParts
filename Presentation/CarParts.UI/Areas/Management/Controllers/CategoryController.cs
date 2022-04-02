using CarParts.UI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace CarParts.UI.Areas.Management.Controllers
{
    //[Authorize(Roles ="Admin")]
    public class CategoryController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CategoryController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [HttpGet]
        public  async Task<IActionResult> ListCategory()
        {
            var client=_httpClientFactory.CreateClient();
          var token=  User.Claims.SingleOrDefault(x => x.Type == "accessToken")?.Value;
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer",token);
         var response= await   client.GetAsync("https://localhost:7076/api/Categories");
            if (response.IsSuccessStatusCode)
            {
                var jsonString= await response.Content.ReadAsStringAsync();
                  var list= JsonSerializer.Deserialize<List<CategoryListResponseModel>>(jsonString,new JsonSerializerOptions
                {
                    PropertyNamingPolicy=JsonNamingPolicy.CamelCase,
                });
                return View(list);
            }
            else 
            {
                return RedirectToAction("Index", "Home");
            }
            
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
