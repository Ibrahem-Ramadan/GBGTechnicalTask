using AutoMapper;
using GBGTechnicalTask.Core.Features.Students.Commands.Models;
using GBGTechnicalTask.Data.Entities;

namespace GBGTechnicalTask.Core.Mapping.Enrollments
{
    public partial class EnrollmentProfile:Profile
    {
        public EnrollmentProfile()
        {
            AddEnrollmentMapping();
        }
    }
}
