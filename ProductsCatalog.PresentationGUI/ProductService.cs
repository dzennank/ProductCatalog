using Newtonsoft.Json;
using ProductsCatalog.Infrastructure.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ProductsCatalog.PresentationGUI
{
    public class ProductService
    {
        private readonly HttpClient _client;

        public ProductService()
        {
            _client = new HttpClient();
        }

        public async Task<List<ProductDTO>> GetProductsAsync()
        {
            string apiUrl = "https://localhost:7139/api/Products";
            HttpResponseMessage response = await _client.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();
                var products = JsonConvert.DeserializeObject<List<ProductDTO>>(jsonResponse);
                return products;
            }
            else
            {
                throw new HttpRequestException(
                    "Došlo je do greške prilikom preuzimanja proizvoda."
                );
            }
        }

        public async Task<bool> AddProductAsync(CreateProductDto createProductDto)
        {
            var jsonContent = Newtonsoft.Json.JsonConvert.SerializeObject(createProductDto);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync(
                "https://localhost:7139/api/Products/AddProduct",
                content
            );

            return response.IsSuccessStatusCode;
        }
        public async Task<bool> UpdateProductAsync(int id, UpdateProductDto updateProductDto)
        {
            var jsonContent = Newtonsoft.Json.JsonConvert.SerializeObject(updateProductDto);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await _client.PutAsync(
                $"https://localhost:7139/api/Products/{id}",
                content
            );

            return response.IsSuccessStatusCode;
        }
        public async Task<bool> DeleteProductAsync(int id)
        {
            var response = await _client.DeleteAsync(
                $"https://localhost:7139/api/Products/{id}"
            );

            return response.IsSuccessStatusCode;
        }
        public async Task<IEnumerable<ProductDTO>> GetFilteredProductsAsync(string filter)
        {
            // https://localhost:7139/api/Products/filtered?productName=test&minPrice=0&maxPrice=1111'
            var response = await _client.GetAsync($"https://localhost:7139/api/Products/filtered?{filter}");

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
            
                return Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<ProductDTO>>(jsonResponse);
            }

            
            return Enumerable.Empty<ProductDTO>();
        }
    }
}
