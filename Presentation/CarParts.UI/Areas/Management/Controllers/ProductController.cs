using CarParts.UI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
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
            var response = await client.GetAsync("https://localhost:7076/api/Product");
            if (response.IsSuccessStatusCode)
            {

                var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                };

                

                var jsonString = await response.Content.ReadAsStringAsync();
                var list = System.Text.Json.JsonSerializer.Deserialize<List<ProductModel>>(jsonString, options);
                return View(list);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

        }
        [HttpGet]
        public IActionResult NewProduct()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> NewProduct(ProductModel myCat)
        {
            var client = _httpClientFactory.CreateClient();
            var token = User.Claims.SingleOrDefault(x => x.Type == "accessToken")?.Value;
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            Guid ids = Guid.NewGuid();
            myCat.Id = ids;
            var stringContent = new StringContent(JsonConvert.SerializeObject(myCat), Encoding.UTF8, "application/json");
            var result = await client.PostAsync("https://localhost:7076/api/Product", stringContent);

            return View();
        }
        [HttpGet]
        public async Task<IActionResult> DetailAsync(Guid id)
        {
            var client = _httpClientFactory.CreateClient();
            var token = User.Claims.SingleOrDefault(x => x.Type == "accessToken")?.Value;
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var result = await client.GetAsync("https://localhost:7076/api/Product/" + id);
            if (result.IsSuccessStatusCode)
            {

                var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                };
                var jsonString = await result.Content.ReadAsStringAsync();
                var oneCategory = System.Text.Json.JsonSerializer.Deserialize<ProductModel>(jsonString);
                return View(oneCategory);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

        }
        //Burada Halay Cekıyoruz..
        //Kankam
        /// <summary>
        /// C
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> UpdateProduct(Guid id)
        {
            var client = _httpClientFactory.CreateClient();
            var token = User.Claims.SingleOrDefault(x => x.Type == "accessToken")?.Value;
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var result = await client.GetAsync("https://localhost:7076/api/Product/" + id);
            if (result.IsSuccessStatusCode)
            {
                var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                };
                var jsonString = await result.Content.ReadAsStringAsync();
                var oneCategory = System.Text.Json.JsonSerializer.Deserialize<ProductModel>(jsonString);
                return View(oneCategory);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpPost]
        public async Task<IActionResult> UpdateProduct(ProductModel myCat)
        {
            var client = _httpClientFactory.CreateClient();
            var token = User.Claims.SingleOrDefault(x => x.Type == "accessToken")?.Value;
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            Guid ids = Guid.NewGuid();
            myCat.Id = ids;
            var stringContent = new StringContent(JsonConvert.SerializeObject(myCat), Encoding.UTF8, "application/json");
            var result = await client.PutAsync("https://localhost:7076/api/Product", stringContent);

            return View();
        }
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            HttpClient client = new HttpClient();
            var token = User.Claims.SingleOrDefault(x => x.Type == "accessToken")?.Value;
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            await client.DeleteAsync("https://localhost:7076/api/Product?id=" + id);
            return RedirectToAction("Index", "Home");

        }
    }
}