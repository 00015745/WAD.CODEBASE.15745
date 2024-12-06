using Swashbuckle.AspNetCore.Annotations;

namespace EventManagement00015745.DTO
{
    public class CreateOrderDto
    {
        [SwaggerSchema("ID of the user who placed the order")]
        public int? UserId { get; set; }

        [SwaggerSchema("ID of the ticket purchased")]
        public int TicketId { get; set; }

        [SwaggerSchema("Quantity of tickets ordered")]
        public int Quantity { get; set; }
    }

}
