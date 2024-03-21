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

        public async Task<List<Product>> GetProductsAsync()
        {
            return await _productRepository.GetProductsAsync();
        }

        public async Task<Product> CreateProductAsync(Product product)
        {
            return await _productRepository.CreateProductAsync(product);
        }

        public async Task<Product> UpdateProductAsync(Product product)
        {
            var objectData = await _productRepository.GetProductByIdAsync(product.Id);

            if (objectData is null)
                return null;

            objectData.Code = product.Code;
            objectData.Value = product.Value;
            objectData.Description = product.Description;
            objectData.RegistrationDate = product.RegistrationDate;

            return await _productRepository.UpdateProductAsync(objectData);
        }
    }
}
