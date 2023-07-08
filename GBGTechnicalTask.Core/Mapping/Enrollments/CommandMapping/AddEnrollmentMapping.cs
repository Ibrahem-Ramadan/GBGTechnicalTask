using GBGTechnicalTask.Core.Features.Enrollments.Commands.Models;
using GBGTechnicalTask.Core.Features.Enrollments.Commands.Responses;
using GBGTechnicalTask.Data.Entities;

namespace GBGTechnicalTask.Core.Mapping.Enrollments
{
    public partial class EnrollmentProfile
    {
        private void AddEnrollmentMapping()
        {
            CreateMap<AddEnrollmentCommand, Enrollment>();

            CreateMap<Enrollment, AddEnrollmentResponse>();
        }
    }
}
