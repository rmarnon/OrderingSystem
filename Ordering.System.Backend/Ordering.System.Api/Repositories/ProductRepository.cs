﻿using Microsoft.EntityFrameworkCore;
using Ordering.System.Api.Entities;
using Ordering.System.Api.Exceptions;
using Ordering.System.Api.Repositories.Data;
using Ordering.System.Api.Repositories.Interfaces;

namespace Ordering.System.Api.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationContext _context;

        public ProductRepository(ApplicationContext context) => _context = context;

        public async Task<Product> CreateProductAsync(Product product)
        {
            try
            {
                using (_context)
                {
                    _context.Products.Add(product);
                    await _context.SaveChangesAsync();
                    return product;
                }
            }
            catch (ApiException e)
            {
                throw new ApiException("Falha ao cadastrar o produto.", e);
            }
        }

        public async Task<Product> DeleteProductAsync(Product product)
        {
            try
            {
                using (_context)
                {
                    _context.Products.Remove(product);
                    await _context.SaveChangesAsync();
                    return product;
                }
            }
            catch (ApiException e)
            {
                throw new ApiException("Falha ao deletar o produto.", e);
            }
        }

        public async Task<bool> ExistProductByIdAsync(Guid id)
        {
            return await _context.Products.AnyAsync(p => p.Id == id);
        }

        public async Task<Product> GetProductByIdAsync(Guid id)
        {
            return await _context
                .Products
                .AsQueryable()
                .AsNoTrackingWithIdentityResolution()
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Product>> GetProductsAsync(Pagination pagination)
        {
            return await _context
                .Products
                .AsQueryable()
                .AsNoTrackingWithIdentityResolution()
                .Skip((pagination.PageNumber - 1) * pagination.PageSize)
                .Take(pagination.PageSize)
                .ToListAsync();
        }

        public async Task<Product> UpdateProductAsync(Product product)
        {
            try
            {
                using (_context)
                {
                    _context.Products.Update(product);
                    await _context.SaveChangesAsync();
                    return product;
                }
            }
            catch (ApiException e)
            {
                throw new ApiException("Falha ao atualizar o produto.", e);
            }
        }
    }
}
