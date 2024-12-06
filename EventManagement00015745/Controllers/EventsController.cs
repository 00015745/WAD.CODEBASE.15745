using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EventManagement00015745.Entities;
using EventManagement00015745.Services;
using Microsoft.AspNetCore.Authorization;

namespace EventManagement00015745.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    
    public class EventsController : ControllerBase
    {
        private readonly EventService _eventService;

        public EventsController(EventService eventService)
        {
            _eventService = eventService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var events = await _eventService.GetEvents();
            return Ok(events);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var eventItem = await _eventService.GetEventById(id);
            if (eventItem == null) return NotFound();

            return Ok(eventItem);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] Event newEvent)
        {
            var createdEvent = await _eventService.CreateEvent(newEvent);
            return CreatedAtAction(nameof(Get), new { id = createdEvent.Id }, createdEvent);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Update(int id, [FromBody] Event updatedEvent)
        {
            var result = await _eventService.UpdateEvent(id, updatedEvent);
            if (!result) return NotFound();

            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _eventService.DeleteEvent(id);
            if (!result) return NotFound();

            return NoContent();
        }
    }
}
