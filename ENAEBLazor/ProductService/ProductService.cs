using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;


namespace ENAEBLazor.ProductService
{
    public class ProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Product>> GetAllProducts()
        {
            return await _httpClient.GetFromJsonAsync<List<Product>>("/products");
        }

        public async Task<Product> GetProductById(string id)
        {
            return await _httpClient.GetFromJsonAsync<Product>($"/products/{id}");
        }

        public async Task<HttpResponseMessage> CreateProduct(Product product)
        {
            return await _httpClient.PostAsJsonAsync("/products", product);
        }

        public async Task<HttpResponseMessage> UpdateProduct(string id, Product product)
        {
            return await _httpClient.PutAsJsonAsync($"/products/{id}", product);
        }

        public async Task<HttpResponseMessage> DeleteProduct(string id)
        {
            return await _httpClient.DeleteAsync($"/products/{id}");
        }
    }
}

public class Product
{
    public string _Id { get; set; }
    public string NombreENAE { get; set; }
    public string DescripcionENAE { get; set; }
    public decimal PrecioENAE { get; set; }
}
