using Bogus;
using Examich.Entity.Data.Exam;
using System.Collections.Generic;
using System.Linq;

namespace Examich.Entity.Seed.Seeder
{
    public static class ExamSeeder
    {
        public static void Seed(ExamichDbContext dbContext)
        {
            if (dbContext.Exams.Any()) return;

            var exams = new List<ExamEntity>();
            var users = UserSeeder.GetTestUsers(dbContext);


            var f = new Faker("en");
            for (int i = 0; i < 3; i++)
            {
                var questions = new List<QuestionEntity>();

                for (int j = 0; j < f.Random.Number(11000, 11500); j++)
                {
                    var answers = new List<AnswerEntity>();

                    for (int l = 0; l < f.Random.Number(4, 6); l++)
                    {
                        answers.Add(
                            new AnswerEntity()
                            {
                                Text = string.Join(" ", f.Lorem.Words(f.Random.Number(3,6))),
                                IsRight = f.Random.Bool(),
                            }
                        );
                    }

                    questions.Add(new QuestionEntity()
                    {
                        Text = string.Join(" ", f.Lorem.Words(f.Random.Number(6, 16))) + "?",
                        Answers = answers
                    });
                }
                var user = users[i];
                exams.Add(new ExamEntity()
                {
                    Id = user.Id,
                    Name = string.Join(" ", f.Lorem.Words(f.Random.Number(3, 6))),
                    Description = string.Join(" ", f.Lorem.Words(f.Random.Number(6, 16))),
                    Creator = user,
                    User = user,
                    Questions = questions,
                }); ;

            }

            dbContext.Exams.AddRange(exams);
            dbContext.SaveChanges();
        }
    }
}