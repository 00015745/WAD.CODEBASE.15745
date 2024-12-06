using EventManagement00015745.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace EventManagement00015745.Services
{
    public class EventService
    {
        private readonly EventManagement00015745Context _context;

        public EventService(EventManagement00015745Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Event>> GetEvent() => await _context.Event.ToListAsync();

        public async Task<Event?> GetEventById(int id) => await _context.Event.FindAsync(id);

        public async Task<Event?> CreateEvent(Event newEvent)
        {
            _context.Event.Add(newEvent);
            await _context.SaveChangesAsync();
            return newEvent;
        }

        public async Task<bool> UpdateEvent(int id, Event updatedEvent)
        {
            var eventToUpdate = await _context.Event.FindAsync(id);
            if (eventToUpdate == null) return false;

            eventToUpdate.Title = updatedEvent.Title;
            eventToUpdate.Description = updatedEvent.Description;
            eventToUpdate.StartDate = updatedEvent.StartDate;
            eventToUpdate.EndDate = updatedEvent.EndDate;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteEvent(int id)
        {
            var eventToDelete = await _context.Event.FindAsync(id);
            if (eventToDelete == null) return false;

            _context.Event.Remove(eventToDelete);
            await _context.SaveChangesAsync();
            return true;
        }

        internal async Task<IEnumerable<Event>> GetEvents()
        {
           return await _context.Event.ToListAsync();
        }
    }
}
