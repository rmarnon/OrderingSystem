using AutoMapper;
using Ordering.System.Api.Entities;
using Ordering.System.Api.Models;
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

        public async Task<ProductViewModel> GetProductByIdAsync(Guid id)
        {
            return await _productRepository.GetProductByIdAsync(id)
                .ContinueWith(task => _mapper.Map<ProductViewModel>(task.Result));
        }

        public async Task<IEnumerable<ProductViewModel>> GetProductsAsync(Pagination pagination)
        {
            return await _productRepository.GetProductsAsync(pagination)
                .ContinueWith(task => _mapper.Map<IEnumerable<ProductViewModel>>(task.Result));
        }

        public async Task<Product> CreateProductAsync(ProductInputModel product)
        {
            var exist = await _productRepository.ExistProductByIdAsync(product.Id);

            if (exist) return null;

            var newProduct = _mapper.Map<Product>(product);

            return await _productRepository.CreateProductAsync(newProduct);
        }

        public async Task<Product> UpdateProductAsync(ProductInputModel product)
        {
            var exist = await _productRepository.ExistProductByIdAsync(product.Id);

            if (!exist) return null;

            var updatedProduct = _mapper.Map<Product>(product);
            updatedProduct.Id = product.Id;

            return await _productRepository.UpdateProductAsync(updatedProduct);
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
