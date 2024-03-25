using Ordering.System.Api.Dtos;
using Ordering.System.Api.Entities;

namespace Ordering.System.Api.Services.Interfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderDto>> GetOrdersAsync(Pagination pagination);
        Task<OrderDto> GetOrderByIdAsync(Guid id);
        Task<Order> CreateOrderAsync(Order order);
        Task<Order> UpdateOrderAsync(Order order);
        Task<bool> ExistOrderAsync(Guid id);
        Task<Order> DeletOrderByIdAsync(Guid id);
    }
}
