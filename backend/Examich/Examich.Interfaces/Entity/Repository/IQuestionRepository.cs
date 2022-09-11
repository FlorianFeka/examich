using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Examich.DTO.Question;

namespace Examich.Interfaces.Entity.Repository
{
    public interface IQuestionRepository
    {
        Task<int> CreateQuestionAsync(Guid examId, CreateQuestionDTO createQuestionDto);
        Task<GetQuestionDTO> DuplicateQuestionAsync(Guid examId, Guid questionId);
        Task<GetQuestionDTO> GetQuestionByIdAsync(Guid id);
        Task<List<GetQuestionDTO>> GetQuestionsByTextOrAnswerAsync(string text);
        Task<List<GetQuestionDTO>> GetQuestionsByExamIdAsync(Guid examId);
        Task<int> UpdateQuestionAsync(Guid questionId, Guid examId, UpdateQuestionDTO updateQuestion);
        Task<int> DeleteQuestionAsync(Guid questionId, Guid examId);
    }
}