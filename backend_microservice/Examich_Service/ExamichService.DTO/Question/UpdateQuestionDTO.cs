using System.Collections.Generic;
using ExamichService.DTO.Question.Answer;

namespace ExamichService.DTO.Question
{
    public class UpdateQuestionDTO
    {
        public string Text { get; set; }
        public IEnumerable<CreateAnswerDTO> Answers { get; set; }
    }
}