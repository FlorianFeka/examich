using System;
using Examich.DTO.User;
using Examich.Interfaces.Entity.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Examich.Controllers.Extensions;

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
        public IActionResult GetInfo()
        {
            if (!this.TryGetUserId(out Guid userId))
            {
                return Unauthorized();
            }

            return Ok(_userRepository.GetUserById(userId));
        }
    }
}
