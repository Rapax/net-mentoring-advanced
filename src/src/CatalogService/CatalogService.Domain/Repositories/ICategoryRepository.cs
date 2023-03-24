using CatalogService.Domain.Entities;

namespace CatalogService.Domain.Repositories
{
    public interface ICategoryRepository
    {
        Task<Category?> GetAsync(int id);

        Task<IEnumerable<Category>> GetAllAsync();

        Task<int> AddAsync(Category entity);

        Task<bool> UpdateAsync(Category entity);

        Task<bool> DeleteAsync(int id);
    }
}
