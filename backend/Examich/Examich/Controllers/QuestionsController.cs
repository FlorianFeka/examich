using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Examich.Controllers.Extensions;
using Examich.DTO.Question;
using Examich.Exceptions;
using Examich.Interfaces.Entity.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Examich.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly IQuestionRepository _questionRepository;

        public QuestionsController(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }
        
        #region QUESTIONS ENDPOINT
        [HttpGet("{questionId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetQuestionDTO))]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(string))]
        public async Task<IActionResult> GetOneQuestion(Guid questionId)
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

        [HttpGet("Exam/{examId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetQuestionDTO>))]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(string))]
        public async Task<IActionResult> GetQuestionsByExam(Guid examId)
        {
            try
            {
                return Ok(await _questionRepository.GetQuestionsByExamIdAsync(examId));
            }
            catch (ExamichDbException e)
            {
                return Conflict(e.Message);
            }
        }
        
        [HttpPost("Duplicate/{questionId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(string))]
        public async Task<IActionResult> DupliacteQuestion(Guid questionId)
        {
            try
            {
                if (!this.TryGetUserId(out Guid _))
                {
                    return Unauthorized();
                }
                await _questionRepository.DuplicateQuestionAsync(questionId);
            }
            catch (ExamichDbException e)
            {
                return Conflict(e.Message);
            }
            return Ok();
        }
        
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(string))]
        public async Task<IActionResult> CreateQuestion([FromBody] CreateQuestionDTO createQuestionDto)
        {
            try
            {
                if (!this.TryGetUserId(out Guid _))
                {
                    return Unauthorized();
                }
                await _questionRepository.CreateQuestionAsync(createQuestionDto);
            }
            catch (ExamichDbException e)
            {
                return Conflict(e.Message);
            }
            return Ok();
        }
        
        [HttpPut("{questionId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(string))]
        public async Task<IActionResult> UpdateQuestion(Guid questionId, [FromBody] UpdateQuestionDTO updateQuestionDto)
        {
            try
            {
                if (!this.TryGetUserId(out Guid _))
                {
                    return Unauthorized();
                }
                await _questionRepository.UpdateQuestionAsync(questionId, updateQuestionDto);
            }
            catch (ExamichDbException e)
            {
                return Conflict(e.Message);
            }
            return Ok();
        }

        [HttpDelete("{questionId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(string))]
        public async Task<IActionResult> DeleteQuestion(Guid questionId)
        {
            if (!this.TryGetUserId(out Guid _))
            {
                return Unauthorized();
            }
            
            try
            {
                await _questionRepository.DeleteQuestionAsync(questionId);
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