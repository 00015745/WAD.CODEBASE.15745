using EventManagement00015745.DTO;
using EventManagement00015745.Entities;
using EventManagement00015745.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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

        private int GetAuthenticatedUserId()
        {
            var userIdClaim = User?.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
                throw new UnauthorizedAccessException("User not authenticated");

            return int.Parse(userIdClaim.Value);
        }

        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            var userId = GetAuthenticatedUserId();
            var orders = await _orderService.GetOrders(userId);
            return Ok(orders);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderDto newOrder)
        {
            var userId = GetAuthenticatedUserId();
            var createdOrder = await _orderService.CreateOrder(newOrder, userId);
            return CreatedAtAction(nameof(GetOrders), new { id = createdOrder.Id }, createdOrder);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var userId = GetAuthenticatedUserId();
            var result = await _orderService.DeleteOrder(id, userId);
            if (!result) return NotFound();
            return NoContent();
        }

    }
}
