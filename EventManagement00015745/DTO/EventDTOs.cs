using Swashbuckle.AspNetCore.Annotations;

namespace EventManagement00015745.DTO
{
    public class CreateEventDto
    {
        [SwaggerSchema("Title of the event")]
        public string Title { get; set; }

        [SwaggerSchema("Detailed description of the event")]
        public string Description { get; set; }

        [SwaggerSchema("Start date and time of the event", Format = "date-time")]
        public DateTime StartDate { get; set; }

        [SwaggerSchema("End date and time of the event", Format = "date-time")]
        public DateTime EndDate { get; set; }
    }
    public class UpdateEventDto
    {
        [SwaggerSchema("Title of the event")]
        public string Title { get; set; }

        [SwaggerSchema("Detailed description of the event")]
        public string Description { get; set; }

        [SwaggerSchema("Start date and time of the event", Format = "date-time")]
        public DateTime StartDate { get; set; }

        [SwaggerSchema("End date and time of the event", Format = "date-time")]
        public DateTime EndDate { get; set; }
    }

}
