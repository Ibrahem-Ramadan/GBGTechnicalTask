using GBGTechnicalTask.Core.Bases.Response;
using GBGTechnicalTask.Core.Features.Students.Queries.Responses;
using MediatR;

namespace GBGTechnicalTask.Core.Features.Students.Queries.Models
{
    public class GetStudentListQuery:IRequest<Response<IList<GetStudentResponse>>>
    {
    }
}
