using AutoMapper;
using Ordering.System.Api.Entities;
using Ordering.System.Api.Models;
using Ordering.System.Api.Repositories.Interfaces;
using Ordering.System.Api.Services.Interfaces;

namespace Ordering.System.Api.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly IMapper _mapper;
        private readonly ISupplierRepository _supplierRepository;

        public SupplierService(ISupplierRepository productRepository, IMapper mapper)
        {
            _mapper = mapper;
            _supplierRepository = productRepository;
        }

        public async Task<SupplierViewModel> GetSupplierByIdAsync(Guid id)
        {
            return await _supplierRepository.GetSupplierByIdAsync(id)
                .ContinueWith(task => _mapper.Map<SupplierViewModel>(task.Result));
        }

        public async Task<IEnumerable<SupplierViewModel>> GetSuppliersAsync(Pagination pagination)
        {
            return await _supplierRepository.GetSuppliersAsync(pagination)
                .ContinueWith(task => _mapper.Map<IEnumerable<SupplierViewModel>>(task.Result));
        }

        public async Task<Supplier> CreateSupplierAsync(SupplierInputModel supplier)
        {
            var exist = await _supplierRepository.ExistSupplierByIdAsync(supplier.Id);

            if (exist) return null;

            var newSupplier = _mapper.Map<Supplier>(supplier);

            return await _supplierRepository.CreateSupplierAsync(newSupplier);
        }

        public async Task<Supplier> UpdateSupplierAsync(SupplierInputModel supplier)
        {
            var exist = await _supplierRepository.ExistSupplierByIdAsync(supplier.Id);

            if (!exist)
                return null;

            var updatedSupplier = _mapper.Map<Supplier>(supplier);
            updatedSupplier.Id = supplier.Id;

            return await _supplierRepository.UpdateSupplierAsync(updatedSupplier);
        }

        public async Task<Supplier> DeletSupplierByIdAsync(Guid id)
        {
            var supplier = await _supplierRepository.GetSupplierByIdAsync(id);

            if (supplier is null) return null;

            return await _supplierRepository.DeleteSupplierAsync(supplier);
        }

        public async Task<bool> ExistSupplierAsync(Guid id)
        {
            return await _supplierRepository.ExistSupplierByIdAsync(id);
        }
    }
}
