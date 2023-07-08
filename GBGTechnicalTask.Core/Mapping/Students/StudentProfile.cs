using AutoMapper;
using GBGTechnicalTask.Core.Features.Students.Commands.Models;
using GBGTechnicalTask.Data.Entities;

namespace GBGTechnicalTask.Core.Mapping.Students
{
    public partial class StudentProfile:Profile
    {
        public StudentProfile()
        {
            AddStudentMapping();
            GetStudentMapping();
        }
    }
}
