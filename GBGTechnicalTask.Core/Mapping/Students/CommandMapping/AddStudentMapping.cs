using GBGTechnicalTask.Core.Features.Students.Commands.Models;
using GBGTechnicalTask.Core.Features.Students.Commands.Responses;
using GBGTechnicalTask.Data.Entities;

namespace GBGTechnicalTask.Core.Mapping.Students
{
    public partial class StudentProfile
    {
        private void AddStudentMapping()
        {
            CreateMap<AddStudentCommand, Student>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.StudentName))
                .ForMember(dest => dest.Id, opt => opt.Ignore());
            
            CreateMap<Student, AddStudentResponse>();
        }
    }
}
