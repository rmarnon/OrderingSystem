namespace Ordering.System.Api.Models
{
    public class ItemInputModel
    {
        public double Price { get; init; }
        public uint Quantity { get; init; }
        public Guid ProductId { get; init; }
    }
}
