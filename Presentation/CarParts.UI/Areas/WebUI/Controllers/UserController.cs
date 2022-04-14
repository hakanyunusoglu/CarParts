using CarParts.UI.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace CarParts.UI.Areas.WebUI.Controllers
{
    [Area("WebUI")]
    public class UserController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public UserController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> SignIn()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignIn(UserLoginModel model)
        {
            var client = _httpClientFactory.CreateClient();
            var requestContent = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7076/api/Auth/SignIn", requestContent);
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var tokenModel = JsonSerializer.Deserialize<JwtResponseModel>(jsonData, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                });
                JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
                var token = handler.ReadJwtToken(tokenModel?.Token);
                if (token != null)
                {
                    var claims = token.Claims.ToList();
                    claims.Add(new Claim("accessToken", tokenModel?.Token == null ? "" : tokenModel.Token));
                    ClaimsIdentity identity = new ClaimsIdentity(claims, JwtBearerDefaults.AuthenticationScheme);
                    var authProps = new AuthenticationProperties
                    {
                        ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(30),
                        IsPersistent = true,
                    };
                    await HttpContext.SignInAsync(JwtBearerDefaults.AuthenticationScheme, new ClaimsPrincipal(identity), authProps);
                    string myRole = User.FindFirstValue(ClaimTypes.Role);
                    switch (myRole)
                    {
                        case "Admin":
                            return RedirectToAction("Index", "Home");
                            break;
                        case "Seller":
                            return RedirectToAction("Index", "Home");
                            break;
                        case "Supplier":
                            return RedirectToAction("Index", "Home");
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Email  Veya Şifre Hatalı");
                }
            }
            else
            {
                ModelState.AddModelError("", "Email  Veya Şifre Hatalı");
            }
            return View();
        }
    }
}
