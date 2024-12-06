using Swashbuckle.AspNetCore.Annotations;

namespace EventManagement15745.Entities
{
    public class Event
    {
        [SwaggerSchema("Unique identifier of the event")]
        public int Id { get; set; }

        [SwaggerSchema("Title of the event")]
        public string? Title { get; set; }

        [SwaggerSchema("Detailed description of the event")]
        public string? Description { get; set; }

        [SwaggerSchema("Start date and time of the event", Format = "date-time")]
        public DateTime? StartDate { get; set; }

        [SwaggerSchema("End date and time of the event", Format = "date-time")]
        public DateTime? EndDate { get; set; }

        [SwaggerSchema("Location of the event")]
        public string? Location { get; set; }

        [SwaggerSchema("ID of the organizer")]
        public int? OrganizerId { get; set; }
    }
}
