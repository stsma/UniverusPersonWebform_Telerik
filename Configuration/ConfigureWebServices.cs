using Application.Interfaces;
using Domain.Models;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace UniverusPersonAPI.Configuration
{
    public static class ConfigureWebServices
    {
        public static IServiceCollection AddWebServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<DataContext>(options => options.UseInMemoryDatabase(databaseName: "UniverusDB"));

            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IPersonTypeRepository, PersonTypeRepository>();
            return services;
        }
    }
}