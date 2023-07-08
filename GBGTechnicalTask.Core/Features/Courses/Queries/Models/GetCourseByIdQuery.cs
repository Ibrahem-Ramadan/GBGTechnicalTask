using GBGTechnicalTask.Core.Bases.Response;
using GBGTechnicalTask.Core.Features.Courses.Queries.Responses;
using GBGTechnicalTask.Data.Entities;
using MediatR;

namespace GBGTechnicalTask.Core.Features.Courses.Queries.Models
{
    public class GetCourseByIdQuery:IRequest<Response<GetCourseResponse>>
    {
        public int id { get; set; }
    }
}
