using CarParts.UI.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace CarParts.UI.Areas.Management.Controllers
{
    [Area("Management")]
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
        public IActionResult LockedScreen()
        {
            return View();
        }
        public IActionResult SignIn()
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
                var tokenModel = JsonSerializer.Deserialize<JwtResponseModel>(jsonData,new JsonSerializerOptions
                {
                    PropertyNamingPolicy=JsonNamingPolicy.CamelCase, 
                });
                JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
                // handler.ReadToken=> Bunu Kullanırsak Gerıye SecurityToken Doner sonra bunu tekrar jsontokene cevırmemız gerekır
              var token=  handler.ReadJwtToken(tokenModel?.Token);
                if(token != null)
                {
                    //var roles=  token.Claims.Where(x => x.Type == ClaimTypes.Role).Select(x => x.Value);
                    //     if (roles.Contains("Admin"))
                    //     {

                    //     }
                    var claims = token.Claims.ToList();
                    claims.Add(new Claim("accessToken", tokenModel?.Token == null ? "" : tokenModel.Token));
                    ClaimsIdentity identity = new ClaimsIdentity(claims,JwtBearerDefaults.AuthenticationScheme);
                    var authProps = new AuthenticationProperties
                    {
                        ExpiresUtc = DateTimeOffset.UtcNow,
                        IsPersistent = true,
                    };
                   await HttpContext.SignInAsync(JwtBearerDefaults.AuthenticationScheme, new ClaimsPrincipal(identity), authProps);
                    return RedirectToAction("Index", "Home");
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
        public IActionResult SignOut()
        {

            return View();
        }
        public IActionResult SignUp()
        {


            return View();
        }
        public IActionResult ForgotPassword()
        {
            return View();
        }
    }
}
