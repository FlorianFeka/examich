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

        private const string CORRECT_COLOR = "#008000";

        public async Task<byte[]> GeneratePdfAsync(Guid examId, bool markAnswers)
        {
            if (!await _examRepository.ExamExistsAsync(examId)) throw new ExamichDbException("Exam does not exist.");
            var exam = await _examRepository.GetExamByIdAsync(examId);
            QuestPDF.Settings.DocumentLayoutExceptionThreshold = 10000;

            return Document.Create(container =>
                {
                    container.Page(page =>
                    {
                        page.Size(PageSizes.A4);
                        page.Margin(2, Unit.Centimetre);
                        page.PageColor(Colors.White);

                        page.Header().AlignTop().AlignRight().Image("Assets/logo.png");

                        page.Content()
                            .PaddingVertical(1, Unit.Centimetre)
                            .Column(column =>
                            {
                                column.Spacing(2);
                                column.Item()
                                    .Text(exam.Name)
                                    .SemiBold().FontSize(36);

                                foreach (var question in exam.Questions)
                                {
                                    column.Item().PaddingTop(20).Text(x => x.Span(question.Text));

                                    foreach (var answer in question.Answers)
                                    {
                                        column.Item().Row(row =>
                                        {
                                            row.Spacing(10);
                                            row.AutoItem().Text("  -");

                                            if (markAnswers && answer.IsRight) row.RelativeItem().Text(answer.Text).FontColor(CORRECT_COLOR);
                                            else row.RelativeItem().Text(answer.Text);
                                        });                                   
                                    }
                                }
                            });

                        page.Footer()
                            .AlignCenter()
                            .Text(x =>
                            {
                                x.Span("Page ");
                                x.CurrentPageNumber();
                                x.Span(" of ");
                                x.TotalPages();
                            });
                    });
                })
                // TODO: check what symbols are not allowed to use in filename
                .GeneratePdf();
        }
    }
}
