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
    [Route("api/UsersService/[controller]")]
    [ResponseCache(NoStore = true, Location = ResponseCacheLocation.None)]  
    public class InfoController : ControllerBase
    {

        [HttpGet("Health")]
        public string Get()
        {
            return "Healthy";
        }
    }
}
