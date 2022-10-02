using ExamichService.Entity.Data.Exam;
using Microsoft.EntityFrameworkCore;

namespace ExamichService.Entity
{
    public class ExamichServiceDbContext : DbContext
    {
        public DbSet<ExamEntity> Exams { get; set; }
        public DbSet<QuestionEntity> Questions { get; set; }
        public DbSet<AnswerEntity> Answers { get; set; }

        public ExamichServiceDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            ExamEntity.OnModelBuilding(modelBuilder);
            AnswerEntity.OnModelBuilding(modelBuilder);
        }
    }
}
