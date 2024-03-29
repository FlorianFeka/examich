﻿using System;
using ExamichUserService.Entity.Data.Base;
using Microsoft.EntityFrameworkCore;

namespace ExamichUserService.Entity.Data.Exam
{
    public class AnswerEntity : AuditEntity
    {
        public string Text { get; set; }
        public bool IsRight { get; set; }

        public Guid QuestionId { get; set; }
        public QuestionEntity Question { get; set; }

        public static new void OnModelBuilding(ModelBuilder builder)
        {
            builder.Entity<AnswerEntity>()
                .Property(a => a.Text)
                .IsRequired();

            builder.Entity<AnswerEntity>()
                .HasOne(a => a.Question)
                .WithMany(q => q.Answers)
                .HasForeignKey(a => a.QuestionId);

            builder.Entity<AnswerEntity>()
                .Property(a => a.IsRight);
        }
    }
}
