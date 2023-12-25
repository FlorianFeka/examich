using System;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using Examich_PDF_Service.Api_Client.API;
using Examich_PDF_Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Examich_PDF_Service.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    [ResponseCache(NoStore = true, Location = ResponseCacheLocation.None)]  
    public class FileController : ControllerBase
    {

        private readonly IPdfCreator _pdfCreator;
        private readonly IExamsApi _examsApi;

        public FileController(IPdfCreator pdfCreator, IExamsApi examsApi)
        {
            _pdfCreator = pdfCreator;
            _examsApi = examsApi;
        }

        [HttpPost("{examId}/PDF")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(string))]
        public async Task<IActionResult> ExportExamToPdf(Guid examId, [FromQuery] bool markAnswers)
        {
            try
            {
                if (!Request.Headers.TryGetValue("Authorization", out var bearer)) return Unauthorized();
                
                var exam = await _examsApi.GetExamByIdAsync(examId, bearer[0].Split(" ")[1]);
                var file = await _pdfCreator.GeneratePdfAsync(markAnswers, exam);
                return Ok(File(file, "application/octet-stream", $"{exam.Name}.pdf"));
            }
            catch (Exception e)
            {
                return Conflict(e.Message);
            }
        }
    }
}
