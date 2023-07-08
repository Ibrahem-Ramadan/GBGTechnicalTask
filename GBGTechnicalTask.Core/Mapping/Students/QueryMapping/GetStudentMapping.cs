using GBGTechnicalTask.Core.Features.Students.Queries.Responses;
using GBGTechnicalTask.Data.Entities;

namespace GBGTechnicalTask.Core.Mapping.Students
{
    public partial class StudentProfile
    {
        private void GetStudentMapping()
        {
            CreateMap<Student, GetStudentResponse>();
        }
    }
}
