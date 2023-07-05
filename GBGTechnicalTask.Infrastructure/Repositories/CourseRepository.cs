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
    }
}
