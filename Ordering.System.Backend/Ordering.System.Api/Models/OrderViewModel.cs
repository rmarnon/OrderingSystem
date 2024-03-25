namespace Ordering.System.Api.Models
{
    public class OrderViewModel
    {
        public string Code { get; init; }
        public uint Quantity { get; init; }
        public double TotalValue { get; init; }
        public DateTime RequestDate { get; init; }
        public SupplierViewModel Supplier { get; init; }
        public virtual IEnumerable<ProductViewModel> Items { get; set; }
    }
}
