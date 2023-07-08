using GBGTechnicalTask.Data.Entities;
using GBGTechnicalTask.Infrastructure.Data;
using GBGTechnicalTask.Infrastructure.InfrastructureBases;
using GBGTechnicalTask.Infrastructure.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace GBGTechnicalTask.Infrastructure.Repositories
{
    public class EnrollmentRepository : GenericRepository<Enrollment>, IEnrollmentRepository
    {
        private readonly DbSet<Enrollment> _enrollments;
        public EnrollmentRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _enrollments = appDbContext.Set<Enrollment>();
        }
    }
}
