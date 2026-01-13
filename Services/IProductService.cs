using WigsByChikaambrose.Models;

namespace WigsByChikaambrose.Services;

public interface IProductService
{
    Task<IEnumerable<Product>> GetAllProductsAsync();
    Task<IEnumerable<Product>> GetFeaturedProductsAsync();
    Task<IEnumerable<Product>> GetProductsByCategoryAsync(int categoryId);
    Task<IEnumerable<Product>> GetProductsByTypeAsync(WigType wigType);
    Task<Product?> GetProductByIdAsync(int id);
    Task<IEnumerable<Product>> SearchProductsAsync(string searchTerm);
}