using Ordering.System.Api.Dtos;
using Ordering.System.Api.Entities;

namespace Ordering.System.Api.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetProductsAsync(Pagination pagination);
        Task<ProductDto> GetProductByIdAsync(Guid id);
        Task<Product> CreateProductAsync(Product product);
        Task<Product> UpdateProductAsync(Product product);
        Task<bool> ExistProductAsync(Guid id);
        Task<Product> DeleteProductByIdAsync(Guid id);
    }
}
