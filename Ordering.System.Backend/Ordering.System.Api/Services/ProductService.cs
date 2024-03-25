using AutoMapper;
using Ordering.System.Api.Dtos;
using Ordering.System.Api.Entities;
using Ordering.System.Api.Mappings;
using Ordering.System.Api.Repositories.Interfaces;
using Ordering.System.Api.Services.Interfaces;

namespace Ordering.System.Api.Services
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<ProductDto> GetProductByIdAsync(Guid id)
        {
            return await _productRepository.GetProductByIdAsync(id)
                .ContinueWith(task => _mapper.Map<ProductDto>(task.Result));
        }

        public async Task<IEnumerable<ProductDto>> GetProductsAsync(Pagination pagination)
        {
            return await _productRepository.GetProductsAsync(pagination)
                .ContinueWith(task => _mapper.Map<IEnumerable<ProductDto>>(task.Result));
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
