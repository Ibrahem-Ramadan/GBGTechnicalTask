using GBGTechnicalTask.Data.Entities;
using MediatR;

namespace GBGTechnicalTask.Core.Features.Students.Commands.Models
{
    public class AddStudentCommand:IRequest<Student>
    {
        public string StudentName { get; set; }
    }
}
