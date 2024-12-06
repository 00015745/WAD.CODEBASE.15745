using Swashbuckle.AspNetCore.Annotations;

namespace EventManagement00015745.Entities
{
    public class Ticket
    {
        [SwaggerSchema("Unique identifier of the ticket")]
        public int Id { get; set; }

        [SwaggerSchema("Event ID associated with the ticket")]
        public int EventId { get; set; }

        [SwaggerSchema("Price of the ticket")]
        public decimal Price { get; set; }

        [SwaggerSchema("Number of tickets available")]
        public int QuantityAvailable { get; set; }
    }
}
