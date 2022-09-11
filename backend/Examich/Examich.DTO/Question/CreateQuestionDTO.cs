using System.Collections.Generic;
using Examich.DTO.Question.Answer;

namespace Examich.DTO.Question
{
    public class CreateQuestionDTO
    {
        public string Text { get; set; }
        public IEnumerable<CreateAnswerDTO> Answers { get; set; }
    }
}