using GBGTechnicalTask.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GBGTechnicalTask.Infrastructure.Data.Config
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(crs => crs.Id);
            builder.Property(crs => crs.Id)
                .ValueGeneratedOnAdd();
            builder.Property(crs=>crs.Name)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(50)
                .IsRequired();
            builder.HasMany(crs => crs.Students)
                .WithMany(stu => stu.Courses)
                .UsingEntity<Enrollment>();
        }
    }
}
