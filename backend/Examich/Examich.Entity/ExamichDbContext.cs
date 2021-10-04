using Examich.Entity.Data.Exam;
using Examich.Entity.Data.User;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Examich.Entity
{
    public class ExamichDbContext : IdentityDbContext
    {
        public DbSet<UserEntity> ApplicationUsers { get; set; }
        public DbSet<ExamEntity> Exams { get; set; }
        public DbSet<QuestionEntity> Questions { get; set; }
        public DbSet<AnswerEntity> Answers { get; set; }

        public ExamichDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            UserEntity.OnModelBuilding(modelBuilder);
            ExamEntity.OnModelBuilding(modelBuilder);
        }
    }
}
