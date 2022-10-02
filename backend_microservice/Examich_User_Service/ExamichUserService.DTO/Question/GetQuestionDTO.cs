using System;
using System.Collections.Generic;
using Examich.DTO.Question.Answer;

namespace Examich.DTO.Question
{
    public class GetQuestionDTO
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public List<GetAnswerDto> Answers { get; set; }
    }
}