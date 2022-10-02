using System.Collections.Generic;
using ExamichUserService.DTO.Question.Answer;

namespace ExamichUserService.DTO.Question
{
    public class UpdateQuestionDTO
    {
        public string Text { get; set; }
        public IEnumerable<CreateAnswerDTO> Answers { get; set; }
    }
}