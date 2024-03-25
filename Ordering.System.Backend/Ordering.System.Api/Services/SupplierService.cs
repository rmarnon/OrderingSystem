using AutoMapper;
using Ordering.System.Api.Dtos;
using Ordering.System.Api.Entities;
using Ordering.System.Api.Mappings;
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

        public async Task<SupplierDto> GetSupplierByIdAsync(Guid id)
        {
            return await _supplierRepository.GetSupplierByIdAsync(id)
                .ContinueWith(task => _mapper.Map<SupplierDto>(task.Result));
        }

        public async Task<IEnumerable<SupplierDto>> GetSuppliersAsync(Pagination pagination)
        {
            return await _supplierRepository.GetSuppliersAsync(pagination)
                .ContinueWith(task => _mapper.Map<IEnumerable<SupplierDto>>(task.Result));
        }

        public async Task<Supplier> CreateSupplierAsync(Supplier supplier)
        {
            var exist = await _supplierRepository.ExistSupplierByIdAsync(supplier.Id);

            if (exist) return null;

            return await _supplierRepository.CreateSupplierAsync(supplier);
        }

        public async Task<Supplier> UpdateSupplierAsync(Supplier supplier)
        {
            var supplierData = await _supplierRepository.GetSupplierByIdAsync(supplier.Id);

            if (supplierData is null)
                return null;

            supplierData.Uf = supplier.Uf;
            supplierData.Name = supplier.Name;
            supplierData.Cnpj = supplier.Cnpj;
            supplierData.Email = supplier.Email.Trim();
            supplierData.SocialReason = supplier.SocialReason.Trim();

            return await _supplierRepository.UpdateSupplierAsync(supplierData);
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
