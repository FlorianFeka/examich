using Examich.DTO.Exam;
using System.Collections.Generic;

namespace Examich.Interfaces.Entity.Repository
{
    public interface IExamRepository
    {
        void AddExam(CreateExamDto createExam);
        IEnumerable<GetExamDto> GetExamsByName(string name);
        IEnumerable<GetExamDto> GetExamsByUserId(string userId);
        GetExamDto GetExamById(string id);
        GetExamDto DuplicateExam(DuplicateExamDto duplicateExam);
    }
}
