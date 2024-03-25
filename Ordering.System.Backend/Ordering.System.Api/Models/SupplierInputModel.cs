using Ordering.System.Api.Enums;

namespace Ordering.System.Api.Models
{
    public class SupplierInputModel
    {
        public Guid Id { get; init; } = Guid.Empty;
        public Uf Uf { get; init; }
        public string Name { get; init; }
        public string Cnpj { get; init; }
        public string Email { get; init; }
        public string SocialReason { get; init; }
    }
}
