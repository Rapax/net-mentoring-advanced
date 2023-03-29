using CatalogService.Infrastructure.Persistance.Configurations;
using Microsoft.EntityFrameworkCore;

namespace CatalogService.Infrastructure.Persistance.Context
{
    internal class CatalogServiceContext : DbContext
    {
        public CatalogServiceContext(DbContextOptions options)
            :base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EntityConfiguration<>).Assembly);
        }
    }
}
