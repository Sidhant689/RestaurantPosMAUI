using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RestaurantPosMAUI.Application.Auth;
using RestaurantPosMAUI.Infrastructure;
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

            // Add JWT Service
            services.AddScoped<IJwtService,JwtService>();

            //Add Services

        }
    }
}
