using Examich.Exceptions;
using Examich.Interfaces.Entity.Repository;
using QuestPDF.Fluent;
using System;
using System.Threading.Tasks;

namespace Examich.Services
{
    public class PdfCreator
    {
        private readonly IExamRepository _examRepository;
        public PdfCreator(IExamRepository examRepository)
        {
            _examRepository = examRepository;
        }

        public async Task GeneratePdf(Guid examId)
        {
            if (!await _examRepository.ExamExistsAsync(examId)) throw new ExamichDbException("Exam does not exist.");
            Document.Create(continaer =>
            {
                
            });
        }
    }
}
