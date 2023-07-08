using GBGTechnicalTask.Infrastructure.IRepositories;
using GBGTechnicalTask.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace GBGTechnicalTask.Infrastructure
{
    public static class ModuleInfrastructureDependencies
    {
        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services)
        {
            services.AddTransient<IStudentRepository,StudentRepository>();
            services.AddTransient<ICourseRepository, CourseRepository>();
            services.AddTransient<IEnrollmentRepository, EnrollmentRepository>();
            return services;
        }
    }
}
