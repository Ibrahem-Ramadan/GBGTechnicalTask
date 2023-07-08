using GBGTechnicalTask.Data.Entities;
using GBGTechnicalTask.Infrastructure.IRepositories;
using GBGTechnicalTask.Infrastructure.Repositories;
using GBGTechnicalTask.Service.IServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace GBGTechnicalTask.Service.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly ILogger<CourseService> _logger;

        public CourseService(ICourseRepository courseRepository, ILogger<CourseService> logger)
        {
            _courseRepository = courseRepository;
            _logger = logger;
        }

        public async Task<Course> AddCourseAsync(Course course)
        {
            return await _courseRepository.AddAsync(course);
        }

        public async Task<Course> GetCourseByIdAsync(int id)
        {
            var course= await _courseRepository.GetByIdAsync(id);
            return course;
        }
        public async Task<IList<Course>> GetCoursesListAsync()
        {
            var courses = await _courseRepository.GetTableAsTracking();
            return courses;
        }

        public async Task<bool> IsCourseNameExist(string courseName)
        {
            var courses = await _courseRepository.GetTableAsNoTracking();
            var courseNameExists = courses.FirstOrDefault(course => course.Name == courseName);
            return courseNameExists != null;
        }
    }
}
