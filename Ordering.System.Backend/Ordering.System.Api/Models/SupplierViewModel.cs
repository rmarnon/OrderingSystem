namespace Ordering.System.Api.Models
{
    public class SupplierViewModel
    {
        public string Uf { get; init; }
        public string Name { get; init; }
        public string Cnpj { get; init; }
        public string Email { get; init; }
        public string SocialReason { get; init; }
        public virtual IEnumerable<OrderViewModel> Orders { get; init; }
    }
}
