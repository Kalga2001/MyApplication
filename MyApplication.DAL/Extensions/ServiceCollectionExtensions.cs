using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyApplication.DAL.Interface;
using MyApplication.DAL.Repositories;

namespace MyApplication.DAL.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IGenericRepository, GenericRepostiory>();

            services.AddDbContext<MyApplicationDbContext>(
            options =>
              options.UseSqlServer(
             configuration.GetConnectionString("MyApplicationConnection"),
             x => x.MigrationsAssembly("MyApplication.DAL.Migrations")));

            return services;
        }
    }
}
