using Ordering.System.Api.Entities;

namespace Ordering.System.Api.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetProductsAsync();
        Task<Product> GetProductByIdAsync(Guid id);
        Task<Product> CreateProductAsync(Product product);
        Task<Product> UpdateProductAsync(Product product);
        Task<bool> ExistProductAsync(Guid id);
        Task<Product> DeleteProductByIdAsync(Guid id);
    }
}
