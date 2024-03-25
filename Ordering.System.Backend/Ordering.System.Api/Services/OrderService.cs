using AutoMapper;
using Ordering.System.Api.Entities;
using Ordering.System.Api.Models;
using Ordering.System.Api.Repositories.Interfaces;
using Ordering.System.Api.Services.Interfaces;

namespace Ordering.System.Api.Services
{
    public class OrderService : IOrderService
    {
        private readonly IMapper _mapper;
        private readonly IOrderRepository _orderRepository;
        private readonly ISupplierRepository _supplierRepository;
        private readonly IProductRepository _productRepository;

        public OrderService(IOrderRepository orderRepository, IMapper mapper, IProductRepository productRepository, ISupplierRepository supplierRepository)
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _supplierRepository = supplierRepository;
        }

        public async Task<OrderViewModel> GetOrderByIdAsync(Guid id)
        {
            return await _orderRepository.GetOrderByIdAsync(id)
                .ContinueWith(task => _mapper.Map<OrderViewModel>(task.Result));
        }

        public async Task<IEnumerable<OrderViewModel>> GetOrdersAsync(Pagination pagination)
        {
            return await _orderRepository.GetOrdersAsync(pagination)
                .ContinueWith(task => _mapper.Map<IEnumerable<OrderViewModel>>(task.Result));
        }

        public async Task<Order> CreateOrderAsync(OrderInputModel orderInput)
        {
            if (orderInput is null)
                return null;

            var order = _mapper.Map<Order>(orderInput);

            foreach (var item in orderInput.Items)
            {
                var subTotal = item.Price * item.Quantity;
                order.Items.Add(new()
                {
                    OrderId = order.Id,
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    SubTotal = subTotal,
                });

                order.TotalValue += subTotal;
                order.Quantity += item.Quantity;
            }

            return await _orderRepository.CreateOrderAsync(order);
        }

        public async Task<Order> UpdateOrderAsync(OrderInputModel order)
        {
            var exist = await _orderRepository.ExistOrderByIdAsync(order.Id);

            if (!exist)
                return null;

            var updatedOrder = _mapper.Map<Order>(order);
            updatedOrder.Id = order.Id;

            return await _orderRepository.UpdateOrderAsync(updatedOrder);
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
