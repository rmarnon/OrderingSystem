namespace Ordering.System.Models.Models
{
    public class Order : Base
    {
        public string Code { get; set; }
        public uint Quantity { get; set; }
        public double TotalValue { get; set; }
        public DateTime RequestDate { get; set; }
        public Supplier Supplier { get; set; }
        public List<OrderItem> Items { get; set; } = new();
    }
}
