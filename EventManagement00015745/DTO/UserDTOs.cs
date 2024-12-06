using Swashbuckle.AspNetCore.Annotations;

namespace EventManagement00015745.DTO
{
    public class RegisterDto
    {
        [SwaggerSchema("Username of the user")]
        public string Username { get; set; }

        [SwaggerSchema("Email address of the user")]
        public string Email { get; set; }

        [SwaggerSchema("Password for the user")]
        public string Password { get; set; }
    }
    public class LoginDto
    {
        [SwaggerSchema("Email address of the user")]
        public string Email { get; set; }

        [SwaggerSchema("Password of the user")]
        public string Password { get; set; }
    }
}
