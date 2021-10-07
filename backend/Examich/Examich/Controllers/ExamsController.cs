using Examich.DTO.Exam;
using Examich.Exceptions;
using Examich.Interfaces.Entity.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Examich.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamsController : ControllerBase
    {
        private readonly IExamRepository _examRepository;

        public ExamsController(IExamRepository examRepository)
        {
            _examRepository = examRepository;
        }

        [HttpGet("{examId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetExamDto))]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(string))]
        public IActionResult GetOneExam(string examId)
        {
            try
            {
                return Ok(_examRepository.GetExamById(examId));
            } catch(ExamichDbException e)
            {
                return Conflict(e.Message);
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(string))]
        public IActionResult CreateExam([FromBody] CreateExamDto createExamDto)
        {
            try
            {
                var userId = User.Claims
                    .Where(x => x.Type == ClaimTypes.NameIdentifier)
                    .Select(x => x.Value)
                    .FirstOrDefault();
                if (userId == null) return Conflict("User does not exist.");
                _examRepository.AddExam(userId, createExamDto);
                return Ok();
            }
            catch (ExamichDbException e)
            {
                return Conflict(e.Message);
            }
        }

        [HttpGet("User")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<GetExamDto>))]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(string))]
        public IActionResult GetAllExamsFromUser()
        {
            var userId = User.Claims
                .Where(x => x.Type == ClaimTypes.NameIdentifier)
                .Select(x => x.Value)
                .FirstOrDefault();
            if (userId == null) return Conflict("User does not exist.");
            return Ok(_examRepository.GetExamsByUserId(userId));
        }
    }
}
