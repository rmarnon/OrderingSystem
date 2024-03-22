using Ordering.System.Api.Entities;
using Ordering.System.Api.Repositories.Interfaces;
using Ordering.System.Api.Services.Interfaces;

namespace Ordering.System.Api.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository _supplierRepository;

        public SupplierService(ISupplierRepository productRepository) => _supplierRepository = productRepository;

        public async Task<Supplier> GetSupplierByIdAsync(Guid id)
        {
            return await _supplierRepository.GetSupplierByIdAsync(id);
        }

        public async Task<IEnumerable<Supplier>> GetSuppliersAsync()
        {
            return await _supplierRepository.GetSuppliersAsync();
        }

        public async Task<Supplier> CreateSupplierAsync(Supplier supplier)
        {
            var exist = await _supplierRepository.ExistSupplierByIdAsync(supplier.Id);

            if (exist) return null;

            return await _supplierRepository.CreateSupplierAsync(supplier);
        }

        public async Task<Supplier> UpdateSupplierAsync(Supplier supplier)
        {
            var objectData = await _supplierRepository.GetSupplierByIdAsync(supplier.Id);

            if (objectData is null)
                return null;

            objectData.Uf = supplier.Uf;
            objectData.Name = supplier.Name;
            objectData.Cnpj = supplier.Cnpj;
            objectData.Email = supplier.Email.Trim();
            objectData.SocialReason = supplier.SocialReason.Trim();

            return await _supplierRepository.UpdateSupplierAsync(objectData);
        }

        public async Task<Supplier> DeletSupplierByIdAsync(Guid id)
        {
            var supplier = await _supplierRepository.GetSupplierByIdAsync(id);

            if (supplier is null) return null;

            return await _supplierRepository.DeleteSupplierByIdAsync(supplier);
        }

        public async Task<bool> ExistSupplierAsync(Guid id)
        {
            return await _supplierRepository.ExistSupplierByIdAsync(id);
        }
    }
}
