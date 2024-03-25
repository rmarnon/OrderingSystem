using AutoMapper;
using Ordering.System.Api.Entities;
using Ordering.System.Api.Helper;
using Ordering.System.Api.Models;
using System.Text.RegularExpressions;

namespace Ordering.System.Api.Mappings
{
    public class OrderingMapper : Profile
    {
        public OrderingMapper()
        {
            CreateMap<OrderInputModel, Order>()
                .ForMember(x => x.Code, opt => opt.MapFrom(p => p.Code.Trim()));

            CreateMap<ProductInputModel, Product>()
                .ForMember(x => x.Code, opt => opt.MapFrom(p => p.Code.Trim()))
                .ForMember(x => x.Description, opt => opt.MapFrom(p => p.Description.Trim()));

            CreateMap<SupplierInputModel, Supplier>()
                .ForMember(x => x.Name, opt => opt.MapFrom(p => p.Name.Trim()))
                .ForMember(x => x.Email, opt => opt.MapFrom(p => p.Email.Trim()))
                .ForMember(x => x.SocialReason, opt => opt.MapFrom(p => p.SocialReason.Trim()))
                .ForMember(x => x.Cnpj, opt => opt.MapFrom(p => Regex.Replace(p.Cnpj, "[^0-9]", string.Empty)));

            CreateMap<OrderItem, ItemViewModel>();
            CreateMap<Product, ProductViewModel>();

            CreateMap<Supplier, SupplierViewModel>()
                .ForMember(x => x.Uf, opt => opt.MapFrom(p => p.Uf.ToString()))
                .ForMember(y => y.Cnpj, opt => opt.MapFrom(p => MaskHelper.FormatCNPJ(p.Cnpj)));

            CreateMap<Order, OrderViewModel>()
                .ForMember(x => x.Quantity, opt => opt.MapFrom(p => CalculateHelper.GetTotalQuantity(p.Items)))
                .ForMember(y => y.TotalValue, opt => opt.MapFrom(p => CalculateHelper.GetTotalValue(p.Items)));            
        }
    }
}
