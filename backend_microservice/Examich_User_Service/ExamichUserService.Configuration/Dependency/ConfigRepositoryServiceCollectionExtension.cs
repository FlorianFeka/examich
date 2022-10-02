using ExamichUserService.Entity.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace ExamichUserService.Configuration.Dependency
{
    public static class ConfigRepositoryServiceCollectionExtension
    {
        public static IServiceCollection AddRepositoryConfig(this IServiceCollection services)
        {
            services.AddTransient<IUserRepository, UserRepository>();

            return services;
        }
    }
}
