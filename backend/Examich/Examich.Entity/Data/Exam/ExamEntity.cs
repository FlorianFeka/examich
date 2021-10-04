using Examich.Entity.Data.Base;
using Examich.Entity.Data.User;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Examich.Entity.Data.Exam
{
    public class ExamEntity : AuditEntity
    {
        public string Name {  get; set; }
        public string Description {  get; set; }

        public IEnumerable<UserEntity> Users { get; set; }
        public IEnumerable<ExamUserEntity> ExamUsers { get; set; }
        public IEnumerable<QuestionEntity> Questions { get; set; }

        public static new void OnModelBuilding(ModelBuilder builder)
        {
            builder.Entity<ExamEntity>()
                .Property(x => x.Name)
                .IsRequired();

            // TODO: unique name per user
            builder.Entity<ExamEntity>()
                .HasIndex(x => x.Name)
                .IsUnique();
        }
    }
}
