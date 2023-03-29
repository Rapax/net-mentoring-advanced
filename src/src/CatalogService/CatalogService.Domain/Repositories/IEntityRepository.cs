using CatalogService.Domain.Common;
using System.Linq.Expressions;

namespace CatalogService.Domain.Repositories
{
    public interface IEntityRepository<T> 
        where T : Entity
    {
        Task<T?> GetAsync(int id, CancellationToken cancellationToken = default, params Expression<Func<T, object>>[] includes);

        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? wherePredicate = null, CancellationToken cancellationToken = default, params Expression<Func<T, object>>[] includes);

        T Add(T entity);

        T Update(T entity);

        void Delete(T entity);
    }
}
