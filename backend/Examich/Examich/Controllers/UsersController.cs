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
    }
}
