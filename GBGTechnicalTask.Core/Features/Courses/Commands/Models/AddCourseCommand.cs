using GBGTechnicalTask.Core.Bases.Response;
using GBGTechnicalTask.Core.Features.Courses.Commands.Responses;
using GBGTechnicalTask.Data.Entities;
using MediatR;

namespace GBGTechnicalTask.Core.Features.Courses.Commands.Models
{
    public class AddCourseCommand:IRequest<Response<AddCourseResponse>>
    {
        public string CourseName { get; set; }
    }
}
