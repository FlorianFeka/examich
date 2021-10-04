using Examich.Entity.Data.Exam;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Examich.Entity.Data.User
{
    public class UserEntity : IdentityUser
    {
        public IEnumerable<ExamEntity> Exams { get; set; }
        public IEnumerable<ExamUserEntity> ExamUsers { get; set; }

        public static void OnModelBuilding(ModelBuilder builder)
        {
            builder.Entity<UserEntity>()
                .HasMany(u => u.Exams)
                .WithMany(e => e.Users)
                .UsingEntity<ExamUserEntity>(
                    eu => eu
                        .HasOne(eu => eu.Exam)
                        .WithMany(e => e.ExamUsers)
                        .HasForeignKey(eu => eu.ExamId),
                    eu => eu
                        .HasOne(eu => eu.User)
                        .WithMany(e => e.ExamUsers)
                        .HasForeignKey(eu => eu.UserId),
                    eu =>
                    {
                        eu.Property(eu => eu.IsOwner).HasDefaultValue(false);
                        eu.HasKey(eu => new { eu.UserId, eu.ExamId });
                    });
        }
    }
}
