using System;
using System.Threading.Tasks;
using Examich_PDF_Service.DTO.Exam;

namespace Examich_PDF_Service.Services
{
    public interface IPdfCreator
    {
        Task<byte[]> GeneratePdfAsync(bool markAnswers, GetExamDto examDto);
    }
}
