namespace Ordering.System.Api.Models
{
    public class OrderInputModel
    {
        public Guid Id { get; init; } = Guid.Empty;
        public string Code { get; init; }
        public DateTime RequestDate { get; init; }
        public Guid SupplierId { get; init; }
        public List<ItemInputModel> Items { get; init; }
    }
}
