﻿using Ordering.System.Api.Entities;

namespace Ordering.System.Api.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<List<Product>> GetProductsAsync(Pagination pagination);
        Task<Product> GetProductByIdAsync(Guid id);
        Task<Product> CreateProductAsync(Product product);
        Task<Product> UpdateProductAsync(Product product);
        Task<bool> ExistProductByIdAsync(Guid id);
        Task<Product> DeleteProductAsync(Product product);
    }
}
