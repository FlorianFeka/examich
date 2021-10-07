using Examich.DTO.Exam;
using System.Collections.Generic;

namespace Examich.Interfaces.Entity.Repository
{
    public interface IExamRepository
    {
        void AddExam(string userId, CreateExamDto createExam);
        void UpdateExam(string examId, string userId, UpdateExamDto updateExam);
        IEnumerable<GetExamDto> GetExamsByName(string name);
        IEnumerable<GetExamDto> GetExamsByUserId(string userId);
        GetExamDto GetExamById(string id);
        GetExamDto DuplicateExam(string examId, string userId);
        void DeleteExam(string examId, string userId);
    }
}
