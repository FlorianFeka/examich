using Examich.Entity.Data.Base;
using Examich.Entity.Data.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Examich.Entity.Data.Exam
{
    public class ExamEntity : AuditEntity, ICloneable
    {
        public string Name {  get; set; }
        public string Description {  get; set; }

        public string CreatorId { get; set; }
        public UserEntity Creator { get; set; }
        public string UserId { get; set; }
        public UserEntity User { get; set; }
        //public IEnumerable<UserEntity> Users { get; set; }
        //public IEnumerable<ExamUserEntity> ExamUsers { get; set; }
        public IEnumerable<QuestionEntity> Questions { get; set; }

        public static new void OnModelBuilding(ModelBuilder builder)
        {
            builder.Entity<ExamEntity>()
                .Property(x => x.Name)
                .IsRequired();

            builder.Entity<ExamEntity>()
                .HasIndex(x => new { x.UserId, x.Name })
                .IsUnique();
        }

        public object Clone()
        {
            
            return new ExamEntity()
            {
                Id = new string(this.Id),
                
            };
        }
    }
}
