namespace Ordering.System.Api.Entities
{
    public abstract class Base
    {
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}
