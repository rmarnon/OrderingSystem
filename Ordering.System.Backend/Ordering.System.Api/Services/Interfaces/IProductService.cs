using Ordering.System.Api.Models;
using Ordering.System.Api.Entities;

namespace Ordering.System.Api.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductViewModel>> GetProductsAsync(Pagination pagination);
        Task<ProductViewModel> GetProductByIdAsync(Guid id);
        Task<Product> CreateProductAsync(ProductInputModel product);
        Task<Product> UpdateProductAsync(ProductInputModel product);
        Task<bool> ExistProductAsync(Guid id);
        Task<Product> DeleteProductByIdAsync(Guid id);
    }
}
