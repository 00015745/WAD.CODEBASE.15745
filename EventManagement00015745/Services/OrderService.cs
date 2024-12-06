using EventManagement00015745.DTO;
using EventManagement00015745.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace EventManagement00015745.Services
{
    public class OrderService
    {
        private readonly EventManagement00015745Context _context;

        public OrderService(EventManagement00015745Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Order>> GetOrders(int userId)
        {
            return await _context.Order
                .Where(o => o.UserId == userId)
               
                .Include(o => o.Ticket).ThenInclude(t=>t.Event)
                .ToListAsync();
        }

        public async Task<Order?> CreateOrder(CreateOrderDto orderDto, int userId)
        {
            var newOrder = new Order
            {
                UserId = userId,
                TicketId = orderDto.TicketId,
                Quantity = orderDto.Quantity,
                OrderDate = DateTime.Now

            };
            _context.Order.Add(newOrder);
            await _context.SaveChangesAsync();

            return newOrder;
        }

        public async Task<bool> DeleteOrder(int id, int userId)
        {
            var orderToDelete = await _context.Order
                .Where(o => o.Id == id && o.UserId == userId) // Ensure the order belongs to the authenticated user
                .FirstOrDefaultAsync();

            if (orderToDelete == null) return false;

            _context.Order.Remove(orderToDelete);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
