﻿using System;

namespace ExamichUserService.DTO.Question.Answer
{
    public class GetAnswerDto
    {
        public Guid Id { get; set; }
        public String Text { get; set; }
        public bool IsRight { get; set; }
    }
}