using GBGTechnicalTask.Core.Features.Courses.Queries.Models;
using GBGTechnicalTask.Data.Entities;
using GBGTechnicalTask.Service.IServices;
using MediatR;

namespace GBGTechnicalTask.Core.Features.Courses.Queries.Handlers
{
    public class CourseHandler : IRequestHandler<GetCourseByIdQuery, Course>
    {
        private readonly ICourseService _courseService;
        public CourseHandler(ICourseService courseService)
        {
            _courseService = courseService;
        }
        public async Task<Course> Handle(GetCourseByIdQuery getCourseByIdRequest, CancellationToken cancellationToken)
        {
            return await _courseService.GetCourseByIdAsync(getCourseByIdRequest.id);
        }
    }
}
