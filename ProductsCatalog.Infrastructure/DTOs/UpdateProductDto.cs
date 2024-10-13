namespace ProductsCatalog.Infrastructure.DTOs
{
    public class UpdateProductDto
    {
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int StockQuantity { get; set; }
        public List<int> CategoryIds { get; set; }
    }
}
