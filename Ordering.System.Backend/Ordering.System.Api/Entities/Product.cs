namespace Ordering.System.Api.Entities
{
    public class Product : Base
    {
        public string Code { get; set; }
        public double Value { get; set; }
        public string Description { get; set; }
        public DateTime RegistrationDate { get; set; }
        public virtual IEnumerable<OrderItem> Orders { get; set; }
    }
}
