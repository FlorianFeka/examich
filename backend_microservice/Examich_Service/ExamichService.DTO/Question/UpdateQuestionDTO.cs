using System.Collections.Generic;
using Examich.DTO.Question.Answer;

namespace Examich.DTO.Question
{
    public class UpdateQuestionDTO
    {
        public string Text { get; set; }
        public IEnumerable<CreateAnswerDTO> Answers { get; set; }
    }
}