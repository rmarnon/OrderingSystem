namespace Ordering.System.Api.Models
{
    public class ItemInputModel
    {
        public double Price { get; set; }
        public uint Quantity { get; set; }
        public Guid ProductId { get; set; }
    }
}
