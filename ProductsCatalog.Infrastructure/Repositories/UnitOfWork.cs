
using ProductsCatalog.Models.DataBase;

namespace ProductsCatalog.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ProductCatalogContext _context;
        public IProductRepository Products { get; private set; }
        
         public UnitOfWork(ProductCatalogContext context,
                      IProductRepository productRepository)
    {
        _context = context;
        Products = productRepository;
    }
        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
