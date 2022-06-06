using System;
using Examich.DTO.Exam;
using Examich.Exceptions;
using Examich.Interfaces.Entity.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Examich.Controllers.Extensions;

namespace Examich.Controllers
{
    [Authorize]
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
        public IActionResult GetOneExam(Guid examId)
        {
            try
            {
                return Ok(_examRepository.GetExamById(examId));
            } 
            catch(ExamichDbException e)
            {
                return Conflict(e.Message);
            }
        }

        [HttpGet("User")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<GetExamDto>))]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(string))]
        public IActionResult GetAllExamsFromUser()
        {
            if (! this.TryGetUserId(out Guid userId))
            {
                return Unauthorized();
            }
            return Ok(_examRepository.GetExamsByUserId(userId));
        }

        [HttpGet("Search")]
        public IActionResult SearchExam([FromQuery]string name)
        {
            return Ok(_examRepository.GetExamsByName(name));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(string))]
        public IActionResult CreateExam([FromBody] CreateExamDto createExamDto)
        {
            try
            {

                if (!this.TryGetUserId(out Guid userId))
                {
                    return Unauthorized();
                }
                _examRepository.AddExam(userId, createExamDto);
            }
            catch (ExamichDbException e)
            {
                return Conflict(e.Message);
            }
            return Ok();
        }


        [HttpPost("Duplicate/{examId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(string))]
        public IActionResult DuplicateExam(Guid examId)
        {
            try
            {
                if (!this.TryGetUserId(out Guid userId))
                {
                    return Unauthorized();
                }
                return Ok(_examRepository.DuplicateExam(examId, userId));
            }
            catch (ExamichDbException e)
            {
                return Conflict(e.Message);
            }
        }

        [HttpPut("{examId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(string))]
        public IActionResult UpdateExam(Guid examId, [FromBody] UpdateExamDto updateExamDto)
        {
            try
            {
                if (!this.TryGetUserId(out Guid userId))
                {
                    return Unauthorized();
                }
                _examRepository.UpdateExam(examId, userId, updateExamDto);
            }
            catch (ExamichDbException e)
            {
                return Conflict(e.Message);
            }
            return Ok();
        }

        [HttpDelete("{examId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(string))]
        public IActionResult DeleteExam(Guid examId)
        {
            if (!this.TryGetUserId(out Guid userId))
            {
                return Unauthorized();
            }
;
            try
            {
                _examRepository.DeleteExam(examId, userId);
            }
            catch (ExamichDbException e)
            {
                return Conflict(e.Message);
            }
            return Ok();
        }
    }
}
