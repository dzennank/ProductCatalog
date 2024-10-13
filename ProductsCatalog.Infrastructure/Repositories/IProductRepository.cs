using ProductsCatalog.Infrastructure.DTOs;
using ProductsCatalog.Models.Models;

namespace ProductsCatalog.Infrastructure.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductDTO>> GetAllAsync();
        Task<Product> GetByIdAsync(int id);
        Task AddAsync(Product product);
        Task UpdateAsync(Product product);
        Task DeleteAsync(int id);
        Task<IEnumerable<ProductDTO>> GetFilteredProducts(string productName, decimal? minPrice, decimal? maxPrice);
    }
}
