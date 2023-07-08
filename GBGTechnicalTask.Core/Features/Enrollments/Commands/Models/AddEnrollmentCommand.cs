using GBGTechnicalTask.Core.Bases.Response;
using GBGTechnicalTask.Core.Features.Enrollments.Commands.Responses;
using GBGTechnicalTask.Data.Entities;
using MediatR;

namespace GBGTechnicalTask.Core.Features.Enrollments.Commands.Models
{
    public class AddEnrollmentCommand:IRequest<Response<AddEnrollmentResponse>>
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
    }
}
