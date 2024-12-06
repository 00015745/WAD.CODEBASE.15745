using EventManagement00015745.DTO;
using EventManagement00015745.Entities;
using EventManagement00015745.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventManagement00015745.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {


        private readonly TicketService _ticketService;

        public TicketsController(TicketService ticketService)
        {
            _ticketService = ticketService;
        }

        // GET: api/tickets
        [HttpGet]
        public async Task<IActionResult> GetTickets()
        {
            var tickets = await _ticketService.GetTickets();
            if (tickets == null)
            {
                return NotFound("No tickets available.");
            }

            return Ok(tickets);
        }

        // GET: api/tickets/{eventId}
        [HttpGet("{eventId}")]
        public async Task<IActionResult> GetTicketsByEvent(int eventId)
        {
            var tickets = await _ticketService.GetTicketsByEventIdAsync(eventId);
            if (tickets == null || tickets.Count == 0)
            {
                return NotFound($"No tickets found for event with ID {eventId}.");
            }

            return Ok(tickets);
        }
        // GET: api/tickets/{eventId}
        [HttpPut("{id}")]

        [Authorize]
        public async Task<IActionResult> UpdateTicket(int id, Ticket ticketDto)
        {
            var tickets = await _ticketService.UpdateTicket(id, ticketDto);
            if (!tickets)
            {
                return NotFound($"No tickets found with ID {id}.");
            }

            return Ok(tickets);
        }

        // POST: api/tickets
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateTicket(CreateTicketDto ticketDto)
        {
            if (ticketDto == null)
            {
                return BadRequest("Ticket data is required.");
            }
            var t = new Ticket
            {
                EventId = ticketDto.EventId,
                Price = ticketDto.Price,
                QuantityAvailable = ticketDto.QuantityAvailable

            };

            var success = await _ticketService.CreateTicket(t);
            if (success == null)
            {
                return BadRequest("Unable to create ticket.");
            }

            return Ok("Ticket created successfully.");
        }
    }
}
