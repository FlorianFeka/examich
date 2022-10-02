using System;
using System.Collections.Generic;
using ExamichService.DTO.Question.Answer;

namespace ExamichService.DTO.Question
{
    public class GetQuestionDTO
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public List<GetAnswerDto> Answers { get; set; }
    }
}