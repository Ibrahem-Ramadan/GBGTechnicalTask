using GBGTechnicalTask.Data.Entities;
using GBGTechnicalTask.Infrastructure.Data.Config;
using Microsoft.EntityFrameworkCore;

namespace GBGTechnicalTask.Infrastructure.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            :base(options){
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(StudentConfiguration).Assembly);
        }

    }
}
