using ExamichService.Controllers.Extensions;
using ExamichService.DTO.Exam;
using ExamichService.Entity.Repository;
using ExamichService.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExamichService.Controllers
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

        #region EXAM ENDPOINTS
        [HttpGet("{examId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetExamInfoDto))]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(string))]
        public async Task<IActionResult> GetOneExam(Guid examId)
        {
            try
            {
                return Ok(await _examRepository.GetExamInfoByIdAsync(examId));
            } 
            catch(ExamichServiceDbException e)
            {
                return Conflict(e.Message);
            }
        }

        [HttpGet("User")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<GetExamInfoDto>))]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(string))]
        public async Task<IActionResult> GetAllExamsFromUser()
        {
            if (!this.TryGetUserId(out Guid userId))
            {
                return Unauthorized();
            }
            return Ok(await _examRepository.GetExamsByUserIdAsync(userId));
        }
        
        [HttpGet("{examId}/Complete")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<GetExamInfoDto>))]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(string))]
        public async Task<IActionResult> GetOneCompleteExam(Guid examId)
        {
            if (!this.TryGetUserId(out Guid userId))
            {
                return Unauthorized();
            }
            return Ok(await _examRepository.GetExamByIdAsync(examId));
        }
        
        [HttpGet("Search")]
        public async Task<IActionResult> SearchExam([FromQuery]string name)
        {
            return Ok(await _examRepository.GetExamsByNameAsync(name));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(string))]
        public async Task<IActionResult> CreateExam([FromBody] CreateExamDto createExamDto)
        {
            try
            {
                if (!this.TryGetUserId(out Guid userId))
                {
                    return Unauthorized();
                }
                await _examRepository.CreateExamAsync(userId, createExamDto);
            }
            catch (ExamichServiceDbException e)
            {
                return Conflict(e.Message);
            }
            return Ok();
        }


        [HttpPost("Duplicate/{examId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(string))]
        public async Task<IActionResult> DuplicateExam(Guid examId)
        {
            try
            {
                if (!this.TryGetUserId(out Guid userId))
                {
                    return Unauthorized();
                }
                return Ok(await _examRepository.DuplicateExamAsync(examId, userId));
            }
            catch (ExamichServiceDbException e)
            {
                return Conflict(e.Message);
            }
        }

        [HttpPut("{examId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(string))]
        public async Task<IActionResult> UpdateExam(Guid examId, [FromBody] UpdateExamDto updateExamDto)
        {
            try
            {
                if (!this.TryGetUserId(out Guid userId))
                {
                    return Unauthorized();
                }
                await _examRepository.UpdateExamAsync(examId, userId, updateExamDto);
            }
            catch (ExamichServiceDbException e)
            {
                return Conflict(e.Message);
            }
            return Ok();
        }

        [HttpDelete("{examId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(string))]
        public async Task<IActionResult> DeleteExam(Guid examId)
        {
            if (!this.TryGetUserId(out Guid userId))
            {
                return Unauthorized();
            }

            try
            {
                await _examRepository.DeleteExamAsync(examId, userId);
            }
            catch (ExamichServiceDbException e)
            {
                return Conflict(e.Message);
            }
            return Ok();
        }
        #endregion
    }
}
