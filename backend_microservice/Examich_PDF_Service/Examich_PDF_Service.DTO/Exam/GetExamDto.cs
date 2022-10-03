using System;
using System.Collections.Generic;
using Examich_PDF_Service.DTO.Question;

namespace Examich_PDF_Service.DTO.Exam
{
    public class GetExamDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid CreatorId { get; set; }
        public Guid UserId { get; set; }
        public IList<GetQuestionDTO> Questions { get; set; }
    }
}