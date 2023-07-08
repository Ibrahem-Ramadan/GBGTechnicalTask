using GBGTechnicalTask.Core.Features.Courses.Commands.Models;
using GBGTechnicalTask.Core.Features.Courses.Commands.Responses;
using GBGTechnicalTask.Core.Features.Courses.Queries.Responses;
using GBGTechnicalTask.Core.Features.Students.Commands.Models;
using GBGTechnicalTask.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBGTechnicalTask.Core.Mapping.Courses
{
    public partial class CourseProfile
    {
        private void AddCourseMapping()
        {
            CreateMap<AddCourseCommand, Course>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.CourseName))
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<Course, AddCourseResponse>();
        }
    }
}
