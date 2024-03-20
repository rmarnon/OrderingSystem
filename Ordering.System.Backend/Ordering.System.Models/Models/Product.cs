namespace Ordering.System.Models.Models
{
    public class Product : Base
    {
        public string Code { get; set; }
        public double Value { get; set; }
        public string Description { get; set; }
        public DateTime RegistrationDate { get; set; }
        public List<OrderItem> Products { get; set; } = new();
    }
}
