using CarParts.UI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CarParts.UI.Areas.Management.Controllers
{
    [Area("Management")]

    [Authorize(Roles ="Admin")]
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

                var options = new JsonSerializerOptions
                {
                  PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                };

               

                var jsonString = await response.Content.ReadAsStringAsync();
                  var list= System.Text.Json.JsonSerializer.Deserialize<List<CategoryListResponseModel>>(jsonString,options);
                return View(list);
            }
            else 
            {
                return RedirectToAction("Index", "Home");
            }
            
        }
        [HttpGet]
<<<<<<< HEAD
        public async Task<IActionResult> DetailAsync(Guid id)
=======
        public IActionResult NewCategory()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> DetailAsync(string id)
>>>>>>> origin/JwtDev
        {
           
            CategoryListResponseModel cat = new CategoryListResponseModel();
            HttpClient client = new HttpClient();
            var token = User.Claims.SingleOrDefault(x => x.Type == "accessToken")?.Value;
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            client.BaseAddress = new Uri("https://localhost:7076/api/");
            var respomseTalk = client.GetAsync("Categories" + "/"+id);
            respomseTalk.Wait();
            var result = respomseTalk.Result;
            if (result.IsSuccessStatusCode)
            {
<<<<<<< HEAD

                var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                };
                var jsonString = await result.Content.ReadAsStringAsync();
                var oneCategory = System.Text.Json.JsonSerializer.Deserialize<CategoryListResponseModel>(jsonString);
                return View(oneCategory);
=======
                var readTask = result.Content.ReadAsStringAsync();
                readTask.Wait();
                var davetiyes = readTask.Result;
                cat = JsonConvert.DeserializeObject<CategoryListResponseModel>(davetiyes);
>>>>>>> origin/JwtDev
            }
            if (cat != null)
            {
                return View(cat);
            }
<<<<<<< HEAD

        }
        [HttpGet]
        public IActionResult NewCategory()
        {
=======
>>>>>>> origin/JwtDev
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> NewCategory(CategoryListResponseModel myCat)
        {
            var client = _httpClientFactory.CreateClient();
            var token = User.Claims.SingleOrDefault(x => x.Type == "accessToken")?.Value;
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            Guid ids = Guid.NewGuid();
            myCat.Id = ids.ToString();
            var stringContent = new StringContent(JsonConvert.SerializeObject(myCat), Encoding.UTF8, "application/json");
            var result = await client.PostAsync("https://localhost:7076/api/Categories",stringContent);

            return View();
        }

        public async Task<IActionResult> UpdateCategory(Guid id)
        {
            var client = _httpClientFactory.CreateClient();
            var token = User.Claims.SingleOrDefault(x => x.Type == "accessToken")?.Value;
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var result = await client.GetAsync("https://localhost:7076/api/Categories/" + id);
            if (result.IsSuccessStatusCode)
            {

                var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                };
                var jsonString = await result.Content.ReadAsStringAsync();
                var oneCategory = System.Text.Json.JsonSerializer.Deserialize<CategoryListResponseModel>(jsonString);
                return View(oneCategory);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCategory(CategoryListResponseModel myCat)
        {
            var client = _httpClientFactory.CreateClient();
            var token = User.Claims.SingleOrDefault(x => x.Type == "accessToken")?.Value;
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            Guid ids = Guid.NewGuid();
            myCat.Id = ids;
            var stringContent = new StringContent(JsonConvert.SerializeObject(myCat), Encoding.UTF8, "application/json");
            var result = await client.PutAsync("https://localhost:7076/api/Categories", stringContent);

            return View();
        }
        public async Task<IActionResult> DeleteCategory(Guid id)
        {
            HttpClient client = new HttpClient();
            var token = User.Claims.SingleOrDefault(x => x.Type == "accessToken")?.Value;
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            await client.DeleteAsync("https://localhost:7076/api/Categories?id="+id);
            return RedirectToAction("Index", "Home");
          
        }
    }
}
