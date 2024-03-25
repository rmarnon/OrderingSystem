using Ordering.System.Api.Enums;

namespace Ordering.System.Api.Dtos
{
    public class SupplierDto
    {
        public Uf Uf { get; init; }
        public string Name { get; init; }
        public string Cnpj { get; init; }
        public string Email { get; init; }
        public string SocialReason { get; init; }
        public virtual IEnumerable<OrderDto> Orders { get; init; }
    }
}
