using Microsoft.AspNetCore.Mvc;

namespace Examich.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ResponseCache(NoStore = true, Location = ResponseCacheLocation.None)]  
    public class InfoController : ControllerBase
    {

        [HttpGet("Health")]
        public string Get()
        {
            return "Healty";
        }
    }
}
