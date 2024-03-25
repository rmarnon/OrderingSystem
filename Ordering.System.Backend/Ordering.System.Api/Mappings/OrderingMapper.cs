using AutoMapper;
using Ordering.System.Api.Dtos;
using Ordering.System.Api.Entities;
using Ordering.System.Api.Helper;

namespace Ordering.System.Api.Mappings
{
    public class OrderingMapper : Profile
    {
        public OrderingMapper()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<Supplier, SupplierDto>();

            CreateMap<Order, OrderDto>()
                .ForMember(x => x.Quantity, opt => opt.MapFrom(p => CalculateHelper.GetTotalQuantity(p.Items)))
                .ForMember(y => y.TotalValue, opt => opt.MapFrom(p => CalculateHelper.GetTotalValue(p.Items)))
                .ForMember(z => z.Products, opt => opt.MapFrom(p=> p.Items.Select(r => r.Product).ToList()));
        }
    }
}
