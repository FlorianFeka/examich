using System.Linq;
using Examich.Entity.Data.Exam;

namespace Examich.Entity.Seed.Seeder
{
    public static class ExamSeeder
    {
        public static async void Seed(ExamichDbContext dbContext)
        {
            if (dbContext.Exams.Any()) return;
            
            dbContext.Exams.AddRange(new ExamEntity[]
            {
                new ()
                {
                    Name = "Geschichte - Französische Revolution",
                    Description = "Nix besonderes",
                    CreatorId = UserSeeder.users[0].Id,
                    Questions  = new QuestionEntity[]
                    {
                        new ()
                        {
                            Text = "Wann war die Französische Revolution?",
                            Answers = new AnswerEntity[]
                            {
                                new ()
                                {
                                    IsRight = true,
                                    Text = "1789-1799"
                                },
                                new ()
                                {
                                    IsRight = true,
                                    Text = "1782-1793"
                                },
                                new ()
                                {
                                    IsRight = true,
                                    Text = "1729-1739"
                                },
                                new ()
                                {
                                    IsRight = true,
                                    Text = "1692-1719"
                                },
                            }
                        }
                    }
                },
                
            });

            await dbContext.SaveChangesAsync();
        }
    }
}