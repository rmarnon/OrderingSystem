namespace Ordering.System.Api.Entities
{
    public class Order : Base
    {
        public string Code { get; set; }
        public uint Quantity { get; set; }
        public double TotalValue { get; set; }
        public DateTime RequestDate { get; set; }
        public Guid SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual List<OrderItem> Items { get; set; } = new();
    }
}
