using Ordering.System.Models.Enums;

namespace Ordering.System.Models.Models
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
