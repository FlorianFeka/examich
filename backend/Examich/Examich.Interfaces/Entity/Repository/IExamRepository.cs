using System;
using Examich.DTO.Exam;
using System.Collections.Generic;

namespace Examich.Interfaces.Entity.Repository
{
    public interface IExamRepository
    {
        void AddExam(Guid userId, CreateExamDto createExam);
        void UpdateExam(Guid examId, Guid userId, UpdateExamDto updateExam);
        IEnumerable<GetExamDto> GetExamsByName(string name);
        IEnumerable<GetExamDto> GetExamsByUserId(Guid userId);
        GetExamDto GetExamById(Guid id);
        GetExamDto DuplicateExam(Guid examId, Guid userId);
        void DeleteExam(Guid examId, Guid userId);
    }
}
