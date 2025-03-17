using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Nature_Hub_Server.Data;
using Nature_Hub_Server.DTO;
using Nature_Hub_Server.Models;

namespace Nature_Hub_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAuthController : ControllerBase
    {
        private readonly NatureProductsDbContext _context;
        private readonly IConfiguration _configuration;

        public UserAuthController(NatureProductsDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;

        }
        [HttpPost("LOGIN")]
        public IActionResult Login(User login)
        {
            var user = _context.Users.SingleOrDefault
                (u => u.Username == login.Username && u.Password == login.Password);
            if (user == null) { return Unauthorized(); }
            var token = GenerateJwtToken(user);
            return Ok(new
            {
                UserName = user.Username,
                Token = token,
                Role=user.Role
            });

        }

        [HttpPost("Register")]
        public IActionResult Register(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return Ok(user);
        }

        private string GenerateJwtToken(User user)
        {
            var claims = new[] {
                new Claim(ClaimTypes.Name,user.Username),
                  new Claim(ClaimTypes.Role,user.Role),

           };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credential = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(5),
                signingCredentials: credential
                );
            return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }
    }
