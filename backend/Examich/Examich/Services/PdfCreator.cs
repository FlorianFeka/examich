using Examich.Entity.Repository;
using Examich.Exceptions;
using QuestPDF.Fluent;
using System;
using System.ComponentModel;
using System.Threading.Tasks;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace Examich.Services
{
    public class PdfCreator : IPdfCreator
    {
        private readonly IExamRepository _examRepository;
        public PdfCreator(IExamRepository examRepository)
        {
            _examRepository = examRepository;
        }

        public async Task GeneratePdf(Guid examId)
        {
            if (!await _examRepository.ExamExistsAsync(examId)) throw new ExamichDbException("Exam does not exist.");
            var exam = await _examRepository.GetExamByIdAsync(examId);
            Document.Create(container =>
                {
                    container.Page(page =>
                    {
                        page.Size(PageSizes.A4);
                        page.Margin(2, Unit.Centimetre);
                        page.PageColor(Colors.White);

                        page.Header()
                            .Text(exam.Name)
                            .SemiBold().FontSize(36);
                    });
                })
                // TODO: check what symbols are not allowed to use in filename
                .GeneratePdf($"{exam.Name}.pdf");
        }
    }
}
