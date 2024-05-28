using Manero_WebApp.Models;


namespace Manero_WebApp.Services;

public class ProductService
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<ProductService> _logger;

    public ProductService(HttpClient httpClient, ILogger<ProductService> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }

    public async Task<List<ProductEntity>> GetAllProductsAsync()
    {
        var products = await _httpClient.GetFromJsonAsync<List<ProductEntity>>("https://manero-products-fa.azurewebsites.net/api/products/all");
        return products ?? new List<ProductEntity>();
    }

    public async Task<ProductEntity?> GetAllProductByIdAsync(string productId)
    {
        var response = await _httpClient.GetAsync($"https://manero-products-fa.azurewebsites.net/api/products/{productId}");
        if (!response.IsSuccessStatusCode)
        {
            _logger.LogError($"Failed to fetch product with id {productId}. Status Code: {response.StatusCode}");
            return null;
        }

        var productJson = await response.Content.ReadAsStringAsync();
        _logger.LogInformation($"Product JSON: {productJson}");

        var product = await response.Content.ReadFromJsonAsync<ProductEntity>();
        if (product == null)
        {
            _logger.LogError($"Product with id {productId} not found.");
        }

        return product;
    }

    public async Task<List<ProductEntity>> GetProductsBytTitleAndBatchAsync(string title, string batchNumber)
    {
        var products = await GetAllProductsAsync();
        var filteredProducts = products
            .Where(f => f.Title == title && f.BatchNumber == batchNumber)
            .ToList();
        return filteredProducts;
    }
}
