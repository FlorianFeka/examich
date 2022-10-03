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
                var bearer = User.Claims
                    .Where(x => x.Type == ClaimTypes.NameIdentifier)
                    .Select(x => x.Value)
                    .FirstOrDefault();
                
                var exam = await _examsApi.GetExamByIdAsync(examId, bearer);
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
