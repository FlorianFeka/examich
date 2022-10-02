using ExamichService.Entity.Data.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace ExamichService.Entity.Data.Exam
{
    public class ExamEntity : AuditEntity
    {
        public string Name {  get; set; }
        public string Description {  get; set; }

        public Guid CreatorId { get; set; }
        public Guid UserId { get; set; }
        public IEnumerable<QuestionEntity> Questions { get; set; }

        public static new void OnModelBuilding(ModelBuilder builder)
        {
            builder.Entity<ExamEntity>()
                .Property(x => x.Name)
                .IsRequired();
        }
    }
}
