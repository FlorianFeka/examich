using System;
using System.Threading.Tasks;

namespace Examich.Services
{
    public interface IPdfCreator
    {
        Task<byte[]> GeneratePdfAsync(Guid examId, bool markAnswers);
    }
}
