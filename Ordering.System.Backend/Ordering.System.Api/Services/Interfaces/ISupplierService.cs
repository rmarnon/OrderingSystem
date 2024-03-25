using Ordering.System.Api.Models;
using Ordering.System.Api.Entities;

namespace Ordering.System.Api.Services.Interfaces
{
    public interface ISupplierService
    {
        Task<bool> ExistSupplierAsync(Guid id);
        Task<IEnumerable<SupplierViewModel>> GetSuppliersAsync(Pagination pagination);
        Task<Supplier> CreateSupplierAsync(SupplierInputModel supplier);
        Task<Supplier> DeletSupplierByIdAsync(Guid id);
        Task<SupplierViewModel> GetSupplierByIdAsync(Guid id);
        Task<Supplier> UpdateSupplierAsync(SupplierInputModel product);
    }
}
