using GBGTechnicalTask.Core.Bases.Response;
using GBGTechnicalTask.Core.Features.Students.Queries.Responses;
using MediatR;

namespace GBGTechnicalTask.Core.Features.Students.Queries.Models
{
    public class GetStudentByIdQuery:IRequest<Response<GetStudentResponse>>
    {
        public int id { get; set; }
    }
}
