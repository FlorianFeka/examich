using Microsoft.AspNetCore.Mvc;

namespace Examich_PDF_Service.Controllers
{
    [ApiController]
    [Route("api/PdfService/[controller]")]
    public class InfoController : ControllerBase
    {
        [HttpGet("Health")]
        public string Info()
        {
            return "Healthy";
        }

        [HttpGet("User")]
        public IActionResult User()
        {
                if (!Request.Headers.TryGetValue("Authorization", out var bearer)) return Unauthorized();
                return Ok(bearer[0].Split(" ")[1]);
        }
    }
}
