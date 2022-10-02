using ExamichService.Entity.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace ExamichService.Configuration.Dependency
{
    public static class ConfigRepositoryServiceCollectionExtension
    {
        public static IServiceCollection AddRepositoryConfig(this IServiceCollection services)
        {
            services.AddTransient<IExamRepository, ExamRepository>();
            services.AddTransient<IQuestionRepository, QuestionRepository>();

            return services;
        }
    }
}
