using GBGTechnicalTask.Data.Entities;
using GBGTechnicalTask.Infrastructure.Data;
using GBGTechnicalTask.Infrastructure.InfrastructureBases;
using GBGTechnicalTask.Infrastructure.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace GBGTechnicalTask.Infrastructure.Repositories
{
    public class CourseRepository : GenericRepository<Course>,ICourseRepository
    {
        private readonly DbSet<Course> _courses;
        public CourseRepository(AppDbContext appDbContext):base(appDbContext)
        {
            _courses = appDbContext.Set<Course>();
        }
        public override async Task<Course> GetByIdAsync(int id)
        {
            return await _courses.Include(crs=>crs.Students).FirstOrDefaultAsync(crs => crs.Id == id);
        }   
    }
}
