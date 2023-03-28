using CatalogService.Domain.Repositories;
using CatalogService.Infrastructure.Persistance.Context;
using CatalogService.Infrastructure.Persistance.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CatalogService.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection UseCatalogServiceInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CatalogServiceContext>(
                options =>
                {
                    options.UseSqlServer(configuration.GetConnectionString("Main"));
                });
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CatalogRepository>();

            return services;
        }
    }
}
