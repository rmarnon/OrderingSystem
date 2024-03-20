namespace Ordering.System.Models.Models
{
    public class OrderItem : Base
    {
        public double Price { get; set; }
        public uint Quantity { get; set; }
        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; }
        public Guid OrderId { get; set; }
        public virtual Order Order { get; set; }
    }
}
