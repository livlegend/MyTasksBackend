using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MyTasksBackend.Models;
using MyTasksBackend.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MyTasksBackend.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly TaskContext _context;

        public AuthController(IConfiguration configuration, TaskContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        [HttpPost("login")]
        public  async Task<IActionResult> LoginAsync([FromBody] LoginRequest request)
        {
            try
            {
                // Exemple de validation d'utilisateur
                var user = await _context.UserItems.FirstOrDefaultAsync(u => u.Email.ToLower() == request.Email.ToLower());

                if (user !=null)
                {
                    if (PasswordService.VerifyPassword(request.Password, user.Password))
                    {
                        var token = GenerateJwtToken(request.Email);
                        return Ok(new {user, token });
                    }
                  
                }
                return Unauthorized("Utilisateur inexistant ou identifiants incorrects");
            }
            catch (Exception ex)
            {
                return Unauthorized("Utilisateur inexistant ou identifiants incorrects");
            }
           
        }

        private string GenerateJwtToken(string username)
        {
            var jwtConfig = _configuration.GetSection("Jwt");

            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Sub, username),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfig["Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: jwtConfig["Issuer"],
                audience: jwtConfig["Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }

    public class LoginRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
