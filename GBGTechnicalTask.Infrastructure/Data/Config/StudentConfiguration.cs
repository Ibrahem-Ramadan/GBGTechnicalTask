using GBGTechnicalTask.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBGTechnicalTask.Infrastructure.Data.Config
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(stu => stu.Id);
            builder.Property(stu => stu.Id).ValueGeneratedOnAdd();
            builder.HasMany(stu => stu.Courses)
                .WithMany(crs => crs.Students)
                .UsingEntity<Enrollment>();
            builder.Property(stu => stu.Name)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
