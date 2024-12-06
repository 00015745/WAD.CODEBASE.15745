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

        public async Task<IEnumerable<Order>> GetOrders() => await _context.Order.Include(o => o.User).Include(o => o.Ticket).ToListAsync();

        public async Task<Order?> CreateOrder(Order newOrder)
        {
            _context.Order.Add(newOrder);
            await _context.SaveChangesAsync();
            return newOrder;
        }

        public async Task<bool> DeleteOrder(int id)
        {
            var orderToDelete = await _context.Order.FindAsync(id);
            if (orderToDelete == null) return false;

            _context.Order.Remove(orderToDelete);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
