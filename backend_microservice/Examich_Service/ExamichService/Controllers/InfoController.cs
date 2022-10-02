using Microsoft.AspNetCore.Mvc;

namespace ExamichService.Controllers
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
