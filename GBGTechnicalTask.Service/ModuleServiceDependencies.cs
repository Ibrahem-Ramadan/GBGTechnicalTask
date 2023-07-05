using GBGTechnicalTask.Service.IServices;
using GBGTechnicalTask.Service.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBGTechnicalTask.Service
{
    public static class ModuleServiceDependencies
    {
        public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
        {
            services.AddTransient<IStudentService,StudentService>();
            services.AddTransient<ICourseService,CourseService>();
            return services;
        }
    }
}
