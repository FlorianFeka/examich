using System;
using System.Threading.Tasks;
using Examich_PDF_Service.DTO.Exam;

namespace Examich_PDF_Service.Api_Client.API
{
    public interface IExamsApi
    {
        Task<GetExamDto> GetExamByIdAsync(Guid examId, string bearerToken);
    }
}