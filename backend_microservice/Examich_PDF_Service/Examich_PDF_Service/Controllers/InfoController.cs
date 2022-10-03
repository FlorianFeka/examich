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
    }
}
