using Ordering.System.Api.Models;
using Ordering.System.Api.Entities;

namespace Ordering.System.Api.Services.Interfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderViewModel>> GetOrdersAsync(Pagination pagination);
        Task<OrderViewModel> GetOrderByIdAsync(Guid id);
        Task<Order> CreateOrderAsync(OrderInputModel order);
        Task<Order> UpdateOrderAsync(OrderInputModel order);
        Task<bool> ExistOrderAsync(Guid id);
        Task<Order> DeletOrderByIdAsync(Guid id);
    }
}
