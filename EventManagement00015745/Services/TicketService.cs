using EventManagement00015745.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace EventManagement00015745.Services
{
    public class TicketService
    {

        private readonly EventManagement00015745Context _context;

        public TicketService(EventManagement00015745Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Ticket>> GetTickets()
        {
            return await _context.Ticket
                         .Include(t => t.Event)  // Eagerly load the Event associated with each Ticket
                         .ToListAsync();
        }

        public async Task<Ticket?> CreateTicket(Ticket newTicket)
        {
            _context.Ticket.Add(newTicket);
            await _context.SaveChangesAsync();
            return newTicket;
        }

        public async Task<bool> UpdateTicket(int id, Ticket updatedTicket)
        {
            var ticketToUpdate = await _context.Ticket.FindAsync(id);
            if (ticketToUpdate == null) return false;

            ticketToUpdate.Price = updatedTicket.Price;
            ticketToUpdate.QuantityAvailable = updatedTicket.QuantityAvailable;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Ticket>> GetTicketsByEventIdAsync(int eventId)
        {
            return await _context.Ticket
                .Where(t => t.EventId == eventId).Include(t => t.Event)
                .ToListAsync();
        }
        public async Task<bool> DeleteTicket(int id)
        {
            var ticketToDelete = await _context.Ticket.FindAsync(id);
            if (ticketToDelete == null) return false;

            _context.Ticket.Remove(ticketToDelete);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
