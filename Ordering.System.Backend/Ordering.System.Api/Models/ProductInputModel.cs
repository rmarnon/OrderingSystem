namespace Ordering.System.Api.Models
{
    public class ProductInputModel
    {
        public Guid Id { get; init; } = Guid.Empty;
        public string Code { get; init; }
        public double Value { get; init; }
        public string Description { get; init; }
        public DateTime RegistrationDate { get; init; }
    }
}
