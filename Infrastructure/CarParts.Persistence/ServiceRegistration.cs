using AutoMapper;
using CarParts.Persistence.Context;
using CarParts.Persistence.Repository;
using CarsParts.Application.Mapping;
using CarsParts.Application.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
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
            services.AddAutoMapper(opt =>
            {
                opt.AddProfiles(new List<Profile>()
    {
        new ProductProfile()
    });

            });
            services.AddMediatR(Assembly.GetExecutingAssembly());

        }
    }
}
