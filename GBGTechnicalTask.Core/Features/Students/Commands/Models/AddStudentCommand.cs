using GBGTechnicalTask.Core.Bases.Response;
using GBGTechnicalTask.Core.Features.Students.Commands.Responses;
using GBGTechnicalTask.Data.Entities;
using MediatR;

namespace GBGTechnicalTask.Core.Features.Students.Commands.Models
{
    public class AddStudentCommand:IRequest<Response<AddStudentResponse>>
    {
        public string StudentName { get; set; }
    }
}
