using GBGTechnicalTask.Data.Entities;
using GBGTechnicalTask.Infrastructure.IRepositories;
using GBGTechnicalTask.Service.IServices;

namespace GBGTechnicalTask.Service.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }
        public async Task<Course> GetCourseByIdAsync(int id)
        {
            return await _courseRepository.GetByIdAsync(id);
        }
    }
}
