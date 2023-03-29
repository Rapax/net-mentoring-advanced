using CatalogService.Domain.Entities;
using CatalogService.Domain.Repositories;
using CatalogService.Infrastructure.Persistance.Context;

namespace CatalogService.Infrastructure.Persistance.Repositories
{
    internal class CatalogRepository : EntityRepository<Category>, ICategoryRepository
    {
        public CatalogRepository(CatalogServiceContext context) 
            : base(context)
        {
        }
    }
}
