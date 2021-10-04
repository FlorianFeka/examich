using Examich.Entity.Repository;
using Examich.Entity.Data.User;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
        public IEnumerable<UserEntity> Get(string username = null)
        {
            return _userRepository.GetUserByUsername(username);
        }
    }
}
