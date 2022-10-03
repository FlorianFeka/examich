using System;
using System.Collections.Generic;
using Examich_PDF_Service.DTO.Question.Answer;

namespace Examich_PDF_Service.DTO.Question
{
    public class CreateQuestionDTO
    {
        public Guid ExamId { get; set; }
        public string Text { get; set; }
        public IEnumerable<CreateAnswerDTO> Answers { get; set; }
    }
}