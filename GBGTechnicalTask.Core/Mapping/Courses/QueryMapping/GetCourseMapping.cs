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
        private void GetCourseMapping()
        {
            CreateMap<Course, GetCourseResponse>();
        }
    }
}
