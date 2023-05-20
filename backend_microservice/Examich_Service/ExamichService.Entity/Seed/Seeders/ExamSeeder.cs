using System;
using Bogus;
using ExamichService.Entity.Data.Exam;
using System.Collections.Generic;
using System.Linq;

namespace ExamichService.Entity.Seed.Seeder
{
    public static class ExamSeeder
    {
        public static string GUID_ZEROS = "00000000-0000-0000-0000-00000000000";
        public static void Seed(ExamichServiceDbContext dbContext)
        {
            if (dbContext.Exams.Any()) return;

            var exams = new List<ExamEntity>();

            var f = new Faker("en");
            for (int i = 0; i < 2; i++)
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

                var userId = Guid.Parse($"{GUID_ZEROS}{i}");
                exams.Add(new ExamEntity()
                {
                    Id = userId,
                    Name = string.Join(" ", f.Lorem.Words(f.Random.Number(3, 6))),
                    Description = string.Join(" ", f.Lorem.Words(f.Random.Number(6, 16))),
                    CreatorId = userId,
                    UserId = userId,
                    Questions = questions,
                }); ;

            }

            dbContext.Exams.AddRange(exams);
            dbContext.SaveChanges();
        }
    }
}