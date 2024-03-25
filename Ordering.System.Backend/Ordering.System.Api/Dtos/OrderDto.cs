namespace Ordering.System.Api.Dtos
{
    public class OrderDto
    {
        public string Code { get; init; }
        public uint Quantity { get; init; }
        public double TotalValue { get; init; }
        public DateTime RequestDate { get; init; }
        public SupplierDto Supplier { get; init; }
        public virtual IEnumerable<ProductDto> Products { get; set; }
    }
}
