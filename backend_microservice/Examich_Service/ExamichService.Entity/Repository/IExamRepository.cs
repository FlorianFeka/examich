using System;
using ExamichService.DTO.Exam;
using System.Collections.Generic;
using System.Threading.Tasks;
using ExamichService.Entity.Data.Exam;

namespace ExamichService.Entity.Repository
{
    public interface IExamRepository
    {
        Task<int> CreateExamAsync(Guid userId, CreateExamDto createExam);
        Task<bool> ExamExistsAsync(Guid examId);
        Task<int> UpdateExamAsync(Guid examId, Guid userId, UpdateExamDto updateExam);
        Task<List<GetExamInfoDto>> GetExamsByNameAsync(string name);
        Task<List<GetExamInfoDto>> GetExamsByUserIdAsync(Guid userId);
        Task<GetExamInfoDto> GetExamInfoByIdAsync(Guid id);
        Task<GetExamDto> GetExamByIdAsync(Guid id);
        Task<GetExamInfoDto> DuplicateExamAsync(Guid examId, Guid userId);
        Task<int> DeleteExamAsync(Guid examId, Guid userId);
    }
}
