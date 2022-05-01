using System;
using Examich.DTO.User;
using Examich.Interfaces.Entity.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Json;

namespace Examich.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        private Guid GetUserId()
        {
            if (Guid.TryParse(User.Claims
                    .Where(x => x.Type == ClaimTypes.NameIdentifier)
                    .Select(x => x.Value)
                    .FirstOrDefault(), out Guid id))
            {
                return id;
            }

            return Guid.Empty;
        }

        [HttpGet]
        public IEnumerable<GetUserDto> Get(string username = null)
        {
            return _userRepository.GetUserByUsername(username);
        }

        [Authorize]
        [HttpOptions]
        public IEnumerable<string> Options()
        {
            return User.Claims.Select(x => $"{x.Type} - {x.Value}");
        }

        [Authorize]
        [HttpGet("/Info")]
        public GetUserDto GetInfo()
        {
            return _userRepository.GetUserById(GetUserId());
        }
    }
}
