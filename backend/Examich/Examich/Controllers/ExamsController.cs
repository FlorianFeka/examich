using System;
using Examich.DTO.Exam;
using Examich.Exceptions;
using Examich.Interfaces.Entity.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Examich.Configuration.EntityProfiles;
using Examich.Controllers.Extensions;
using Examich.DTO.Question;

namespace Examich.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ExamsController : ControllerBase
    {
        private readonly IExamRepository _examRepository;
        private readonly IQuestionRepository _questionRepository;

        public ExamsController(IExamRepository examRepository, IQuestionRepository questionRepository)
        {
            _examRepository = examRepository;
            _questionRepository = questionRepository;
        }

        #region EXAM ENDPOINTS
        [HttpGet("{examId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetExamDto))]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(string))]
        public async Task<IActionResult> GetOneExam(Guid examId)
        {
            try
            {
                return Ok(await _examRepository.GetExamByIdAsync(examId));
            } 
            catch(ExamichDbException e)
            {
                return Conflict(e.Message);
            }
        }

        [HttpGet("User")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<GetExamDto>))]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(string))]
        public async Task<IActionResult> GetAllExamsFromUser()
        {
            if (! this.TryGetUserId(out Guid userId))
            {
                return Unauthorized();
            }
            return Ok(await _examRepository.GetExamsByUserIdAsync(userId));
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
            catch (ExamichDbException e)
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
            catch (ExamichDbException e)
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
            catch (ExamichDbException e)
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
;
            try
            {
                await _examRepository.DeleteExamAsync(examId, userId);
            }
            catch (ExamichDbException e)
            {
                return Conflict(e.Message);
            }
            return Ok();
        }
        #endregion

        #region EXAM QUESTIONS ENDPOINTS

        [HttpGet("{examId}/question/{questionId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetQuestionDTO))]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(string))]
        public async Task<IActionResult> GetOneQuestion(Guid examId, Guid questionId)
        {
            try
            {
                return Ok(await _questionRepository.GetQuestionByIdAsync(questionId));
            }
            catch (ExamichDbException e)
            {
                return Conflict(e.Message);
            }
        }
        
        
        [HttpPost("{examId}/question")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(string))]
        
        public async Task<IActionResult> CreateQuestion([FromRoute] Guid examId, [FromBody] CreateQuestionDTO createQuestionDto)
        {
            try
            {
                if (!this.TryGetUserId(out Guid userId))
                {
                    return Unauthorized();
                }
                await _questionRepository.CreateQuestionAsync(examId, createQuestionDto);
            }
            catch (ExamichDbException e)
            {
                return Conflict(e.Message);
            }
            return Ok();
        }
        #endregion
    }
}
