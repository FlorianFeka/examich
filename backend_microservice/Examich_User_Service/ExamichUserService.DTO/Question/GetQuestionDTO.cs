using System;
using System.Collections.Generic;
using ExamichUserService.DTO.Question.Answer;

namespace ExamichUserService.DTO.Question
{
    public class GetQuestionDTO
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public List<GetAnswerDto> Answers { get; set; }
    }
}