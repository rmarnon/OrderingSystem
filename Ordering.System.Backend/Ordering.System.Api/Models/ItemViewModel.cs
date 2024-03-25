using Ordering.System.Api.Entities;

namespace Ordering.System.Api.Models
{
    public class ItemViewModel
    {
        public uint Quantity { get; set; }
        public double SubTotal { get; set; }
        public virtual ProductViewModel Product { get; set; }
    }
}
