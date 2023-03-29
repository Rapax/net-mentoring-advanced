using CatalogService.Domain.Repositories;
using CatalogService.Infrastructure.Persistance.Context;

namespace CatalogService.Infrastructure.Persistance.Repositories
{
    internal sealed class UnitOfWork : IUnitOfWork
    {
        private readonly CatalogServiceContext _context;

        public UnitOfWork(CatalogServiceContext context)
        {
            _context = context;
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return _context.SaveChangesAsync(cancellationToken);
        }
    }
}
