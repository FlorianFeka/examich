using Examich.Entity.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Examich.Configuration.Dependency
{
    public static class ConfigRepositoryServiceCollectionExtension
    {
        public static IServiceCollection AddRepositoryConfig(this IServiceCollection services)
        {
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IExamRepository, ExamRepository>();
            services.AddTransient<IQuestionRepository, QuestionRepository>();

            return services;
        }
    }
}
