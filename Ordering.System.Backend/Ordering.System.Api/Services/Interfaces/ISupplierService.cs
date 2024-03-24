using Ordering.System.Api.Entities;

namespace Ordering.System.Api.Services.Interfaces
{
    public interface ISupplierService
    {
        Task<bool> ExistSupplierAsync(Guid id);
        Task<IEnumerable<Supplier>> GetSuppliersAsync(Pagination pagination);
        Task<Supplier> CreateSupplierAsync(Supplier supplier);
        Task<Supplier> DeletSupplierByIdAsync(Guid id);
        Task<Supplier> GetSupplierByIdAsync(Guid id);
        Task<Supplier> UpdateSupplierAsync(Supplier product);
    }
}
