using Microsoft.AspNetCore.Mvc;
using ProductsCatalog.Infrastructure.DTOs;
using ProductsCatalog.Infrastructure.Repositories;
using ProductsCatalog.Models.Models;

namespace ProductsCatalog.Infrastructure.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ProductsController(IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _unitOfWork.Products.GetAllAsync();

            return Ok(products);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(id);

            if (product == null)
            {
                return NotFound(); 
            }

            return Ok(product); 
        }

        [HttpPost]
        [Route("AddProduct")]
        public async Task<IActionResult> AddProduct([FromBody] CreateProductDto productDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var product = new Product
            {
                ProductName = productDto.ProductName,
                Price = productDto.Price,
                Description = productDto.Description,
                StockQuantity = productDto.StockQuantity,
                CreatedAt = productDto.CreatedAt,
                ProductCategories = productDto.CategoryIds
                    .Select(categoryId => new ProductCategory
                    {
                        CategoryId = categoryId
                    }).ToList()
            };
            await _unitOfWork.Products.AddAsync(product);
            return CreatedAtAction(nameof(GetProductById), new { id = product.ProductId }, product);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] UpdateProductDto productDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingProduct = await _unitOfWork.Products.GetByIdAsync(id);
            if (existingProduct == null)
            {
                return NotFound();
            }

            // Ažuriraj podatke o proizvodu
            existingProduct.ProductName = productDto.ProductName;
            existingProduct.Price = productDto.Price;
            existingProduct.Description = productDto.Description;
            existingProduct.StockQuantity = productDto.StockQuantity;
            existingProduct.ProductCategories = productDto.CategoryIds
                .Select(categoryId => new ProductCategory
                {
                    CategoryId = categoryId
                }).ToList();

            await _unitOfWork.Products.UpdateAsync(existingProduct); 

            return NoContent(); 
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var existingProduct = await _unitOfWork.Products.GetByIdAsync(id);
            if (existingProduct == null)
            {
                return NotFound(); 
            }

            await _unitOfWork.Products.DeleteAsync(id);

            return NoContent();
        }
        [HttpGet("filtered")]
        public async Task<IActionResult> GetFilteredProducts(
                string productName = null,
                decimal? minPrice = null,
                decimal? maxPrice = null)
        {
            
            var products = await _unitOfWork.Products.GetFilteredProducts(productName, minPrice, maxPrice);

            return Ok(products);
        }
    }
}
