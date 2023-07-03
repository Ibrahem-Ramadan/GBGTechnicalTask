using GBGTechnicalTask.Data.Entities;
using GBGTechnicalTask.Infrastructure.Data;
using GBGTechnicalTask.Infrastructure.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace GBGTechnicalTask.Infrastructure.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly AppDbContext _appDbContext;
        public CourseRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<Course> GetByIdAsync(int id)
        {
            return await _appDbContext.Courses.FindAsync(id);
        }
    }
}
