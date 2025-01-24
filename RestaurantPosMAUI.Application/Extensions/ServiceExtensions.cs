using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RestaurantPosMAUI.Application.Auth;
using RestaurantPosMAUI.Application.Interfaces;
using RestaurantPosMAUI.Application.Services;
using RestaurantPosMAUI.Infrastructure;
using RestaurantPosMAUI.Infrastructure.UnitofWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantPosMAUI.Application.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddResPosMauiServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDBContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            // configure automapper
            services.AddAutoMapper(typeof(AutomapperProfile).Assembly);

            // Register UnitOfWork
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Add JWT Service
            services.AddScoped<IJwtService,JwtService>();

            //Add Services
            services.AddScoped<IUserService,UserService>();
            services.AddScoped<IMenuCategoryService,MenuCategoryservice>();
            services.AddScoped<IMenuItemService, MenuItemService>();
        }
    }
}
