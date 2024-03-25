using Microsoft.EntityFrameworkCore;
using Ordering.System.Api.Entities;
using Ordering.System.Api.Exceptions;
using Ordering.System.Api.Repositories.Data;
using Ordering.System.Api.Repositories.Interfaces;

namespace Ordering.System.Api.Repositories
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly ApplicationContext _context;

        public SupplierRepository(ApplicationContext context) => _context = context;

        public async Task<Supplier> CreateSupplierAsync(Supplier supplier)
        {
            try
            {
                using (_context)
                {
                    _context.Suppliers.Add(supplier);
                    await _context.SaveChangesAsync();
                    return supplier;
                }
            }
            catch (ApiException e)
            {
                throw new ApiException("Falha ao cadastrar o fornecedor.", e);
            }
        }

        public async Task<Supplier> DeleteSupplierAsync(Supplier supplier)
        {
            try
            {
                using (_context)
                {
                    _context.Suppliers.Remove(supplier);
                    await _context.SaveChangesAsync();
                    return supplier;
                }
            }
            catch (ApiException e)
            {
                throw new ApiException("Falha ao deletar o fornecedor.", e);
            }
        }

        public async Task<bool> ExistSupplierByIdAsync(Guid id)
        {
            return await _context.Suppliers.AnyAsync(p => p.Id == id);
        }

        public async Task<Supplier> GetSupplierByIdAsync(Guid id)
        {
            return await _context
                .Suppliers
                .AsQueryable()
                .AsNoTrackingWithIdentityResolution()
                .Include(x => x.Orders)
                    .ThenInclude(y => y.Items)
                    .ThenInclude(z => z.Product)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Supplier>> GetSuppliersAsync(Pagination pagination)
        {
            return await _context
                .Suppliers
                .AsQueryable()
                .AsNoTrackingWithIdentityResolution()
                .Include(x => x.Orders)
                    .ThenInclude(y => y.Items)
                    .ThenInclude(z => z.Product)
                .Skip((pagination.PageNumber - 1) * pagination.PageSize)
                .Take(pagination.PageSize)
                .ToListAsync();
        }

        public async Task<Supplier> UpdateSupplierAsync(Supplier supplier)
        {
            try
            {
                using (_context)
                {
                    _context.Suppliers.Update(supplier);
                    await _context.SaveChangesAsync();
                    return supplier;
                }
            }
            catch (ApiException e)
            {
                throw new ApiException("Falha ao atualizar o fornecedor.", e);
            }
        }
    }
}
