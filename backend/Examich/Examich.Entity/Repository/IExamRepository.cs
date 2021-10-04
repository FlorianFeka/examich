using Examich.DTO.Exam;
using System.Collections.Generic;

namespace Examich.Entity.Repository
{
    public interface IExamRepository
    {
        void AddExam(CreateExamDto exam);
        IEnumerable<GetExamDto> GetExamsByName(string name, string userId);
        IEnumerable<GetExamDto> GetExamsByUserId(string userId);
        GetExamDto GetExamById(string id, string userId);

    }
}
