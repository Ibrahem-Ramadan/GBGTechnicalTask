using GBGTechnicalTask.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GBGTechnicalTask.Infrastructure.Data.Config
{
    public class StudentCourseConfiguration : IEntityTypeConfiguration<Enrollment>
    {
        public void Configure(EntityTypeBuilder<Enrollment> builder)
        {
            builder.HasKey(x => new { x.CourseId , x.StudentId});
        }
    }
}
