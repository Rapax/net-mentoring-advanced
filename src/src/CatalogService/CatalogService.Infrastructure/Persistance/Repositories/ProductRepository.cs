using CatalogService.Domain.Entities;
using CatalogService.Domain.Repositories;
using CatalogService.Infrastructure.Persistance.Context;

namespace CatalogService.Infrastructure.Persistance.Repositories
{
    internal class ProductRepository : EntityRepository<Product>, IProductRepository
    {
        public ProductRepository(CatalogServiceContext context)
            : base(context)
        {
        }
    }
}
