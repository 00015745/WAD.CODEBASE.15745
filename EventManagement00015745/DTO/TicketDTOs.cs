using Swashbuckle.AspNetCore.Annotations;

namespace EventManagement00015745.DTO
{
    public class CreateTicketDto
    {
        [SwaggerSchema("Event ID associated with the ticket")]
        public int EventId { get; set; }

        [SwaggerSchema("Price of the ticket")]
        public decimal Price { get; set; }

        [SwaggerSchema("Number of tickets available")]
        public int QuantityAvailable { get; set; }
    }
    public class UpdateTicketDto
    {
        [SwaggerSchema("Price of the ticket")]
        public decimal Price { get; set; }

        [SwaggerSchema("Number of tickets available")]
        public int QuantityAvailable { get; set; }
    }


}
