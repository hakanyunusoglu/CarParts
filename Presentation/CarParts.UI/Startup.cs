using CarParts.Persistence;

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
            services.AddControllersWithViews();
            services.AddControllers().AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddPersistenceServices();
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapAreaControllerRoute(
                     name: "Management",
                     areaName: "Management",
                     pattern: "Management/{controller=Home}/{action=Index}/{id?}"
                   );
                    endpoints.MapAreaControllerRoute(
                     name: "WebUI",
                     areaName: "WebUI",
                     pattern: "WebUI/{controller=Home}/{action=Index}/{id?}"
                   );
                });
            });
        }
    }
}
