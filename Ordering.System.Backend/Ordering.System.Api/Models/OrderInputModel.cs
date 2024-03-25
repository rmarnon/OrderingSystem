namespace Ordering.System.Api.Models
{
    public class OrderInputModel
    {
        public Guid Id { get; set; } = Guid.Empty;
        public string Code { get; set; }
        public DateTime RequestDate { get; set; }
        public Guid SupplierId { get; set; }
        public List<ItemInputModel> Items { get; set; }
    }
}
