namespace Ordering.System.Api.Entities
{
    public class Order : Base
    {
        public string Code { get; set; }
        public uint Quantity { get; set; }
        public double TotalValue { get; set; }
        public DateTime RequestDate { get; set; }
        public Guid SupplierId { get; set; }
        public Supplier Supplier { get; set; }
        public virtual IEnumerable<OrderItem> Products { get; set; }
    }
}
