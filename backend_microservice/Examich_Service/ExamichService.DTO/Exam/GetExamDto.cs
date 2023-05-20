using System;
using System.Collections.Generic;
using ExamichService.DTO.Question;

namespace ExamichService.DTO.Exam
{
    public class GetExamDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid CreatorId { get; set; }
        public Guid UserId { get; set; }
        public IList<GetQuestionDTO> Questions { get; set; }
    }
}