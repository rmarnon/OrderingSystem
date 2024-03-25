namespace Ordering.System.Api.Entities
{
    public class OrderItem : Base
    {
        public uint Quantity { get; set; }
        public double SubTotal { get; set; }
        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; }
        public Guid OrderId { get; set; }
        public virtual Order Order { get; set; }
    }
}
