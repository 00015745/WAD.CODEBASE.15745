using Swashbuckle.AspNetCore.Annotations;

namespace EventManagement00015745.Entities
{
    public class Order
    {
        [SwaggerSchema("Unique identifier of the order")]
        public int Id { get; set; }

        [SwaggerSchema("ID of the user who placed the order")]
        public int? UserId { get; set; }

        [SwaggerSchema("The user who placed the order")]
        public User? User { get; set; }

        [SwaggerSchema("ID of the ticket purchased")]
        public int TicketId { get; set; }

        [SwaggerSchema("The ticket purchased")]
        public Ticket? Ticket { get; set; }

        [SwaggerSchema("Quantity of tickets ordered")]
        public int Quantity { get; set; }

        [SwaggerSchema("Date and time when the order was placed")]
        public DateTime OrderDate { get; set; }
    }
}
