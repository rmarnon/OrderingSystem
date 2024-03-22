using Microsoft.EntityFrameworkCore;
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
                    _context.Entry(product).State = EntityState.Added;
                    await _context.SaveChangesAsync();
                    return product;
                }
            }
            catch (ApiException e)
            {
                return product;
            }
        }

        public async Task<Product> DeleteProductByIdAsync(Product product)
        {
            try
            {
                using (_context)
                {
                    _context.Entry(product).State = EntityState.Deleted;
                    await _context.SaveChangesAsync();
                    return product;
                }
            }
            catch (ApiException e)
            {
                return product;
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

        public async Task<List<Product>> GetProductsAsync()
        {
            return await _context
                .Products
                .AsQueryable()
                .AsNoTrackingWithIdentityResolution()
                .ToListAsync();
        }

        public async Task<Product> UpdateProductAsync(Product product)
        {
            try
            {
                using (_context)
                {
                    _context.Entry(product).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    return product;
                }
            }
            catch (ApiException e)
            {
                return product;
            }
        }
    }
}
