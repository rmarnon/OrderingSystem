using Microsoft.EntityFrameworkCore;
using Ordering.System.Api.Entities;
using Ordering.System.Api.Exceptions;
using Ordering.System.Api.Repositories.Data;
using Ordering.System.Api.Repositories.Interfaces;

namespace Ordering.System.Api.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationContext _context;

        public OrderRepository(ApplicationContext context) => _context = context;

        public async Task<Order> CreateOrderAsync(Order order)
        {
            try
            {
                using (_context)
                {
                    _context.Entry(order).State = EntityState.Added;
                    await _context.SaveChangesAsync();
                    return order;
                }
            }
            catch (ApiException e)
            {
                throw new ApiException("Falha ao cadastrar o pedido.", e);
            }
        }

        public async Task<Order> DeleteOrderAsync(Order order)
        {
            try
            {
                using (_context)
                {
                    _context.Entry(order).State = EntityState.Deleted;
                    await _context.SaveChangesAsync();
                    return order;
                }
            }
            catch (ApiException e)
            {
                throw new ApiException("Falha ao deletar o pedido.", e);
            }
        }

        public async Task<bool> ExistOrderByIdAsync(Guid id)
        {
            return await _context.Orders.AnyAsync(p => p.Id == id);
        }

        public async Task<Order> GetOrderByIdAsync(Guid id)
        {
            return await _context
                .Orders
                .AsQueryable()
                .AsNoTrackingWithIdentityResolution()
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Order>> GetOrdersAsync(Pagination pagination)
        {
            return await _context
                .Orders
                .AsQueryable()
                .AsNoTrackingWithIdentityResolution()
                .Skip((pagination.PageNumber - 1) * pagination.PageSize)
                .Take(pagination.PageSize)
                .ToListAsync();
        }

        public async Task<Order> UpdateOrderAsync(Order order)
        {
            try
            {
                using (_context)
                {
                    _context.Entry(order).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    return order;
                }
            }
            catch (ApiException e)
            {
                throw new ApiException("Falha ao atualizar o pedido.", e);
            }
        }
    }
}
