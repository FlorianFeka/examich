using System;
using ExamichService.Entity.Data.Base;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ExamichService.Entity.Data.Exam
{
    public class QuestionEntity : AuditEntity
    {
        public string Text { get; set; }

        public Guid ExamId { get; set; }
        public ExamEntity Exam { get; set; }

        public IEnumerable<AnswerEntity> Answers { get; set; }

        public static new void OnModelBuilding(ModelBuilder builder)
        {
            builder.Entity<QuestionEntity>()
                .Property(x => x.Text)
                .IsRequired();

            builder.Entity<QuestionEntity>()
                .HasOne(q => q.Exam)
                .WithMany(e => e.Questions)
                .HasForeignKey(e => e.ExamId);
        }
    }
}
