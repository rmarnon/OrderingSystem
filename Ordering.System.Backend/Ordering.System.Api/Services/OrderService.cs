using AutoMapper;
using Ordering.System.Api.Dtos;
using Ordering.System.Api.Entities;
using Ordering.System.Api.Repositories.Interfaces;
using Ordering.System.Api.Services.Interfaces;

namespace Ordering.System.Api.Services
{
    public class OrderService : IOrderService
    {
        private readonly IMapper _mapper;
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository, IMapper mapper)
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
        }

        public async Task<OrderDto> GetOrderByIdAsync(Guid id)
        {
            return await _orderRepository.GetOrderByIdAsync(id)
                .ContinueWith(task => _mapper.Map<OrderDto>(task.Result));
        }

        public async Task<IEnumerable<OrderDto>> GetOrdersAsync(Pagination pagination)
        {
            return await _orderRepository.GetOrdersAsync(pagination)
                .ContinueWith(task => _mapper.Map<IEnumerable<OrderDto>>(task.Result));
        }

        public async Task<Order> CreateOrderAsync(Order order)
        {
            var exist = await _orderRepository.ExistOrderByIdAsync(order.Id);

            if (exist) return null;

            return await _orderRepository.CreateOrderAsync(order);
        }

        public async Task<Order> UpdateOrderAsync(Order order)
        {
            var orderData = await _orderRepository.GetOrderByIdAsync(order.Id);

            if (orderData is null)
                return null;

            orderData.RequestDate = order.RequestDate;
            orderData.Code = order.Code.Trim();
            orderData.Supplier = order.Supplier;

            return await _orderRepository.UpdateOrderAsync(orderData);
        }

        public async Task<Order> DeletOrderByIdAsync(Guid id)
        {
            var order = await _orderRepository.GetOrderByIdAsync(id);

            if (order is null) return null;

            return await _orderRepository.DeleteOrderAsync(order);
        }

        public async Task<bool> ExistOrderAsync(Guid id)
        {
            return await _orderRepository.ExistOrderByIdAsync(id);
        }
    }
}
