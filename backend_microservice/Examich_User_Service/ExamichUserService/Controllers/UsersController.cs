using ExamichUserService.Controllers.Extensions;
using ExamichUserService.DTO.User;
using ExamichUserService.Entity.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamichUserService.Controllers
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

        [HttpGet("Search")]
        public async Task<List<GetUserDto>> Get(string username = null)
        {
            return await _userRepository.GetUserByUsernameAsync(username);
        }

        [Authorize]
        [HttpOptions]
        public IEnumerable<string> Options()
        {
            return User.Claims.Select(x => $"{x.Type} - {x.Value}");
        }

        [Authorize]
        [HttpGet("Info")]
        public async Task<IActionResult> GetInfo()
        {
            if (!this.TryGetUserId(out Guid userId))
            {
                return Unauthorized();
            }

            return Ok(await _userRepository.GetUserByIdAsync(userId));
        }
    }
}
