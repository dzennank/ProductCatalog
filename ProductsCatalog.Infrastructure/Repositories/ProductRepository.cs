using Microsoft.EntityFrameworkCore;
using ProductsCatalog.Infrastructure.DTOs;
using ProductsCatalog.Models.DataBase;
using ProductsCatalog.Models.Models;

namespace ProductsCatalog.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductCatalogContext _context;
        public ProductRepository(ProductCatalogContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var product = await GetByIdAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<ProductDTO>> GetAllAsync()
        {
            var products = await _context.Products.ToListAsync();

          
            var productDTOs = products.Select(product => new ProductDTO
            {
                Id = product.ProductId,
                ProductName = product.ProductName,
                Price = product.Price,
                Description = product.Description,
                StockQuantity = product.StockQuantity,
                CreatedAt = product.CreatedAt,
              
            });
            return productDTOs;
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<IEnumerable<ProductDTO>> GetFilteredProducts(string productName, decimal? minPrice, decimal? maxPrice)
        {
            var query = _context.Products.AsQueryable();

            if (!string.IsNullOrEmpty(productName))
            {
                query = query.Where(p => p.ProductName.Contains(productName));
            }

            if (minPrice.HasValue)
            {
                query = query.Where(p => p.Price >= minPrice.Value);
            }

            if (maxPrice.HasValue)
            {
                query = query.Where(p => p.Price <= maxPrice.Value);
            }

           
            List<ProductDTO> products = await query.Select(p => new ProductDTO
            {
                Id = p.ProductId,
                ProductName = p.ProductName,
                Price = p.Price,
                Description = p.Description,
                StockQuantity = p.StockQuantity,
                CreatedAt = p.CreatedAt
            }).ToListAsync();

            return products;
        }

        public async Task UpdateAsync(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }
    }
}
