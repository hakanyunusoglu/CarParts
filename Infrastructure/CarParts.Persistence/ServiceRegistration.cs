    using AutoMapper;
using CarParts.Persistence.Context;
using CarParts.Persistence.Repository;
using CarsParts.Application.Mapping;
using CarsParts.Application.Repositories;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CarParts.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<CarPartsDbContext>(options => options.UseNpgsql("User ID=postgres;Password=123456;Host=localhost;Port=5432;Database=CarPartsDB;"));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddAutoMapper(opt =>
            {
                opt.AddProfiles(new List<Profile>()
    {
        new ProductProfile()
    });

            });


        }
        //npm ile node_modules klasörü altında tasarım olarak bootstrap 5 i kullanmak için bu builderi ekledik. UI tasarımlarında dosya olarak node_modules içindeki bootstrap şablonunu kullanacağız
        public static IApplicationBuilder CustomStaticFiles(this IApplicationBuilder app)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "node_modules");
            var options = new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(path),
                RequestPath = "/modules"
            };
            app.UseStaticFiles(options);
            return app;
            //startup.cs
        }
    }
}
