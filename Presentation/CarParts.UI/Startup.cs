using CarParts.Persistence;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace CarParts.UI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson();


            services.AddControllersWithViews();
            services.AddControllers().AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddPersistenceServices();
            services.AddHttpClient();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddCookie(JwtBearerDefaults.AuthenticationScheme, opt=>
            {
                opt.LoginPath = "/User/SignIn";//Hangı Pathle Logın
                opt.LogoutPath = "/User/SignIn";//
                opt.AccessDeniedPath = "/User/AccessDenied";//Kullanıcın yetkısı yok ıse buraya yonlendırme
                opt.Cookie.SameSite = SameSiteMode.Strict;//Sadece o domaınle kullansılsın
                opt.Cookie.HttpOnly = true;//JavaScrıpten koruma
                opt.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
                //Neyle Geldıyse onla gıtsın.. Https>Https
                opt.Cookie.Name = "CarPartsCookie";
            });

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

            }
            else
            {
                app.UseExceptionHandler("/Home/Error");

                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            //CarParts.Persistance içindeki ServiceRegistration içine kendi builderimiz yazdık. UI içerisinde kullanmak için burada çağırdık
            app.CustomStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                app.UseEndpoints(endpoints =>
                {
                    // endpoints.MapAreaControllerRoute(
                    //  name: "Management",
                    //  areaName: "Management",
                    //  pattern: "{area:exists}/{controller}/{action}/{id?}"
                    //);
                    // endpoints.MapAreaControllerRoute(
                    //  name: "WebUI",
                    //  areaName: "WebUI",
                    //  pattern: "WebUI/{controller=Home}/{action=Index}/{id?}"
                    //);
                    endpoints.MapControllerRoute(
                     name: "Management",

                     pattern: "{area:exists}/{controller}/{action}/{id?}");
                    endpoints.MapControllerRoute(
                     name: "default",
                     pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                });
            });
        }
    }
}
