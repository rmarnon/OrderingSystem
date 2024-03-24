using Ordering.System.Api.Entities;
using Ordering.System.Api.Repositories.Interfaces;
using Ordering.System.Api.Services.Interfaces;

namespace Ordering.System.Api.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository) => _productRepository = productRepository;

        public async Task<Product> GetProductByIdAsync(Guid id)
        {
            return await _productRepository.GetProductByIdAsync(id);
        }

        public async Task<IEnumerable<Product>> GetProductsAsync(Pagination pagination)
        {
            return await _productRepository.GetProductsAsync(pagination);
        }

        public async Task<Product> CreateProductAsync(Product product)
        {
            var exist = await _productRepository.ExistProductByIdAsync(product.Id);

            if (exist) return null;

            return await _productRepository.CreateProductAsync(product);
        }

        public async Task<Product> UpdateProductAsync(Product product)
        {
            var productData = await _productRepository.GetProductByIdAsync(product.Id);

            if (productData is null)
                return null;

            productData.Value = product.Value;
            productData.Code = product.Code.Trim();
            productData.Description = product.Description.Trim();
            productData.RegistrationDate = product.RegistrationDate;

            return await _productRepository.UpdateProductAsync(productData);
        }

        public async Task<Product> DeleteProductByIdAsync(Guid id)
        {
            var product = await _productRepository.GetProductByIdAsync(id);

            if (product is null) return null;

            return await _productRepository.DeleteProductAsync(product);
        }

        public async Task<bool> ExistProductAsync(Guid id)
        {
            return await _productRepository.ExistProductByIdAsync(id);
        }
    }
}
