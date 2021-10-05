using Examich.DTO.Exam;
using System.Collections.Generic;

namespace Examich.Interfaces.Entity.Repository
{
    public interface IExamRepository
    {
        void AddExam(CreateExamDto createExam);
        IEnumerable<GetExamDto> GetExamsByName(string name, string userId);
        IEnumerable<GetExamDto> GetExamsByUserId(string userId);
        GetExamDto GetExamById(string id, string userId);
        GetExamDto DuplicateExam(DuplicateExamDto duplicateExam);
    }
}
