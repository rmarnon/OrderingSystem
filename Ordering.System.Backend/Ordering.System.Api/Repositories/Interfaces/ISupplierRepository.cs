using Ordering.System.Api.Entities;

namespace Ordering.System.Api.Repositories.Interfaces
{
    public interface ISupplierRepository
    {
        Task<List<Supplier>> GetSuppliersAsync();
        Task<Supplier> GetSupplierByIdAsync(Guid id);
        Task<Supplier> CreateSupplierAsync(Supplier supplier);
        Task<Supplier> UpdateSupplierAsync(Supplier supplier);
        Task<bool> ExistSupplierByIdAsync(Guid id);
        Task<Supplier> DeleteSupplierAsync(Supplier supplier);
    }
}
