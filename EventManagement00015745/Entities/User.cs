using Swashbuckle.AspNetCore.Annotations;

namespace EventManagement00015745.Entities
{
    public class User
    {
        [SwaggerSchema("Unique identifier of the user")]
        public int Id { get; set; }

        [SwaggerSchema("Username of the user")]
        public string Username { get; set; }

        [SwaggerSchema("Email address of the user")]
        public string Email { get; set; }

        [SwaggerSchema("Hashed password of the user")]
        public string PasswordHash { get; set; }
        public ICollection<Order>? Orders { get; set; }
        public ICollection<Event>? Events { get; set; }
    }
}
