using Ordering.System.Api.Entities;

namespace Ordering.System.Api.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetOrdersAsync();
        Task<Order> GetOrderByIdAsync(Guid id);
        Task<Order> CreateOrderAsync(Order order);
        Task<Order> UpdateOrderAsync(Order order);
        Task<bool> ExistOrderByIdAsync(Guid id);
        Task<Order> DeleteOrderAsync(Order order);
    }
}
