using CatalogService.Domain.Entities;

namespace CatalogService.Domain.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();

        Task<Product?> GetByIdAsync(int id);

        Task<int> InsertAsync(Product entity);

        Task<bool> UpdateAsync(Product entity);

        Task<bool> DeleteAsync(int id);
    }
}
