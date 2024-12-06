using EventManagement00015745.DTO;
using EventManagement00015745.Entities;
using EventManagement00015745.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventManagement00015745.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {

        private readonly OrderService _orderService;

        public OrdersController(OrderService orderService)
        {
            _orderService = orderService;
        }

        // GET: api/orders
        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            var orders = await _orderService.GetOrders();
            return Ok(orders);
        }

        // POST: api/orders
        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderDto orderDto)
        {
            if (orderDto == null)
            {
                return BadRequest("Order data is required.");
            }

            // Create the new order object
            var newOrder = new Order
            {
                UserId = orderDto.UserId,  // Make sure UserId is passed in the DTO or handled from the user (e.g., via JWT)
                TicketId = orderDto.TicketId,
                Quantity = orderDto.Quantity,
                OrderDate = DateTime.UtcNow
            };

            var createdOrder = await _orderService.CreateOrder(newOrder);
            return CreatedAtAction(nameof(GetOrders), new { id = createdOrder.Id }, createdOrder);
        }

        // DELETE: api/orders/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var success = await _orderService.DeleteOrder(id);
            if (!success)
            {
                return NotFound($"Order with ID {id} not found.");
            }

            return NoContent(); // 204 No Content on successful deletion
        }
    }
}
