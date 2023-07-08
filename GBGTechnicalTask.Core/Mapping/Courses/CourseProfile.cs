using AutoMapper;
using GBGTechnicalTask.Core.Features.Courses.Queries.Models;
using GBGTechnicalTask.Data.Entities;

namespace GBGTechnicalTask.Core.Mapping.Courses
{
    public partial class CourseProfile:Profile
    {
        public CourseProfile()
        {
            GetCourseMapping();
            AddCourseMapping();
        }
    }
}
