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

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _productRepository.GetProductsAsync();
        }

        public async Task<Product> CreateProductAsync(Product product)
        {
            var exist = await _productRepository.ExistProductByIdAsync(product.Id);

            if (exist) return null;

            return await _productRepository.CreateProductAsync(product);
        }

        public async Task<Product> UpdateProductAsync(Product product)
        {
            var objectData = await _productRepository.GetProductByIdAsync(product.Id);

            if (objectData is null)
                return null;

            objectData.Value = product.Value;
            objectData.Code = product.Code.Trim();
            objectData.Description = product.Description.Trim();
            objectData.RegistrationDate = product.RegistrationDate;

            return await _productRepository.UpdateProductAsync(objectData);
        }

        public async Task<Product> DeletProductByIdAsync(Guid id)
        {
            var product = await _productRepository.GetProductByIdAsync(id);

            if (product is null) return null;

            return await _productRepository.DeleteProductByIdAsync(product);
        }

        public async Task<bool> ExistProductAsync(Guid id)
        {
            return await _productRepository.ExistProductByIdAsync(id);
        }
    }
}
