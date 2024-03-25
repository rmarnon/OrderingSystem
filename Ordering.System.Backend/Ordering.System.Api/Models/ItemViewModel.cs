using Ordering.System.Api.Entities;

namespace Ordering.System.Api.Models
{
    public class ItemViewModel
    {
        public uint Quantity { get; init; }
        public double SubTotal { get; init; }
        public virtual ProductViewModel Product { get; init; }
    }
}
