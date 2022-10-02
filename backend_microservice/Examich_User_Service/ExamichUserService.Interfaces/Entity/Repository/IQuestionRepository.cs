using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ExamichUserService.DTO.Question;

namespace ExamichUserService.Interfaces.Entity.Repository
{
    public interface IQuestionRepository
    {
        Task<int> CreateQuestionAsync(CreateQuestionDTO createQuestionDto);
        Task<GetQuestionDTO> DuplicateQuestionAsync(Guid questionId);
        Task<GetQuestionDTO> GetQuestionByIdAsync(Guid id);
        Task<List<GetQuestionDTO>> GetQuestionsByTextOrAnswerAsync(string text);
        Task<List<GetQuestionDTO>> GetQuestionsByExamIdAsync(Guid examId);
        Task<int> UpdateQuestionAsync(Guid questionId, UpdateQuestionDTO updateQuestion);
        Task<int> DeleteQuestionAsync(Guid questionId);
    }
}