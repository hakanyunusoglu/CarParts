using CarParts.UI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace CarParts.UI.Areas.Management.Controllers
{
    [Area("Management")]
    [Authorize(Roles = "Admin")]

    public class ProductController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [HttpGet]
        public async Task<IActionResult> ListProduct()
        {
            var client = _httpClientFactory.CreateClient();
            var token = User.Claims.SingleOrDefault(x => x.Type == "accessToken")?.Value;
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await client.GetAsync("https://localhost:7076/api/Categories");
            if (response.IsSuccessStatusCode)
            {

                var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                };

                //var options = new JsonSerializerOptions();
                //options.Converters.Add(new JsonStringEnumConverter());
                //options.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;,
                //options.PropertyNamingPolicy = new UpperCaseNamingPolicy()

                var jsonString = await response.Content.ReadAsStringAsync();
                var list = System.Text.Json.JsonSerializer.Deserialize<List<ProductModel>>(jsonString, options);
                return View(list);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

        }
        public IActionResult NewProduct()
        {
            return View();
        }
        public IActionResult DeleteProduct()
        {
            return View();
        }
        public IActionResult UpdateProduct()
        {
            return View();
        }
    }
}
