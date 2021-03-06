using Examich.DTO;
using Examich.Exceptions;
using Examich.Interfaces.Entity.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Examich.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;

        public AuthController(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        [HttpPost("Register")]
        public IActionResult Register([FromBody] CreateUserDto userDto)
        {
            try
            {
                var id = _userRepository.CreateUser(userDto);
                return Created("https://localhost:5001/users", new { id });
            }
            catch (ExamichDbException e)
            {
                return Conflict(e.Message);
            }
        }

        [HttpPost("Login")]
        public IActionResult Login(LoginDto login)
        {
            var user = _userRepository.GetUserByEmailAndPassword(login.Email, login.Password);
            if(user == null)
                return Unauthorized();

            var claims = new List<Claim>
            {
                new (JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new (ClaimTypes.NameIdentifier, user.Id.ToString()),
                new (ClaimTypes.Email, user.Email),
            };

            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["IssuerSigningKey"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JwtSettings:TokenValidationParameters:ValidIssuer"],
                audience: _configuration["JwtSettings:TokenValidationParameters:ValidAudience"],
                expires: DateTime.Now.AddHours(1),
                claims: claims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo,
                });
        }
    }
}
