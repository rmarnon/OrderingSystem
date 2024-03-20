namespace Ordering.System.Models.Models
{
    public abstract class Base
    {
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}
