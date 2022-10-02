using Microsoft.AspNetCore.Mvc;

namespace Examich.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InfoController : ControllerBase
    {

        [HttpGet("Health")]
        public string Get()
        {
            return "Healty";
        }
    }
}
