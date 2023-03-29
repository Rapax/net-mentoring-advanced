using CatalogService.Domain.Common;
using CatalogService.Domain.Repositories;
using CatalogService.Infrastructure.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CatalogService.Infrastructure.Persistance.Repositories
{
    internal abstract class EntityRepository<T> : IEntityRepository<T>
        where T : Entity
    {
        private readonly CatalogServiceContext _context;

        public EntityRepository(CatalogServiceContext context)
        {
            _context = context;
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? wherePredicate = null, CancellationToken cancellationToken = default, params Expression<Func<T, object>>[] includes)
        {
            var query = BuildQuery(includes);
            if(wherePredicate != null)
            {
                query = query.Where(wherePredicate);
            }

            return await query.ToListAsync(cancellationToken);
        }

        public virtual Task<T?> GetAsync(int id, CancellationToken cancellationToken = default, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = BuildQuery(includes);

            return query.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public virtual T Add(T entity)
        {
            return _context.Set<T>().Add(entity).Entity;
        }

        public virtual void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public virtual T Update(T entity)
        {
            var entityEntry = _context.Set<T>().Update(entity);
            return entityEntry.Entity;
        }

        private IQueryable<T> BuildQuery(Expression<Func<T, object>>[] includes)
        {
            var query = _context.Set<T>().AsQueryable();
            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return query;
        }
    }
}
