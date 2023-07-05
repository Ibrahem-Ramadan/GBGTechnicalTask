using GBGTechnicalTask.Data.Entities;
using MediatR;

namespace GBGTechnicalTask.Core.Features.Courses.Queries.Models
{
    public class GetCourseByIdQuery:IRequest<Course>
    {
        public int id { get; set; }
    }
}
