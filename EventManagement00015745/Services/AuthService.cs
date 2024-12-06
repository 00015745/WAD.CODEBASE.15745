using EventManagement00015745.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System;
using Microsoft.EntityFrameworkCore;

namespace EventManagement00015745.Services
{
    public class AuthService
    {
        private readonly EventManagement00015745Context _context;
        private readonly IConfiguration _configuration;

        public AuthService(EventManagement00015745Context context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<string?> Login(string email, string password)
        {
            var user = await _context.User.FirstOrDefaultAsync(u => u.Email == email);
            if (user == null || !VerifyPassword(password, user.PasswordHash))
                return null;

            return GenerateJwtToken(user);
        }

        public async Task<bool> Register(string username, string email, string password)
        {
            if (await _context.User.AnyAsync(u => u.Email == email)) return false;

            var user = new User
            {
                Username = username,
                Email = email,
                PasswordHash = HashPassword(password)
            };

            _context.User.Add(user);
            await _context.SaveChangesAsync();
            return true;
        }

        private string GenerateJwtToken(User user)
        {
            var claims = new[]
            {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Name, user.Username)
        };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "K7tE1fiDbw9M4g3c",
               
                claims: claims,
                expires: DateTime.Now.AddHours(72),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private string HashPassword(string password)
        {
            var hasher = new PasswordHasher<User>();
            return hasher.HashPassword(null, password);
        }

        private bool VerifyPassword(string password, string hash)
        {
            var hasher = new PasswordHasher<User>();
            return hasher.VerifyHashedPassword(null, hash, password) != PasswordVerificationResult.Failed;
        }
    }
}
