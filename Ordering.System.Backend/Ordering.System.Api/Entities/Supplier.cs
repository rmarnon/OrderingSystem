using Ordering.System.Api.Enums;

namespace Ordering.System.Api.Entities
{
    public class Supplier : Base
    {
        public Uf Uf { get; set; }
        public string Name { get; set; }
        public string Cnpj { get; set; }
        public string Email { get; set; }
        public string SocialReason { get; set; }
        public List<Order> Orders { get; set; } = new();
    }
}
