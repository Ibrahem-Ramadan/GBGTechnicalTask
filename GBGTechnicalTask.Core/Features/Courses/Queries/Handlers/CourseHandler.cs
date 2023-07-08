using AutoMapper;
using GBGTechnicalTask.Core.Bases.Response;
using GBGTechnicalTask.Core.Exceptions;
using GBGTechnicalTask.Core.Features.Courses.Queries.Models;
using GBGTechnicalTask.Core.Features.Courses.Queries.Responses;
using GBGTechnicalTask.Data.Entities;
using GBGTechnicalTask.Service.IServices;
using MediatR;

namespace GBGTechnicalTask.Core.Features.Courses.Queries.Handlers
{
    public class CourseHandler :
        ResponseHandler,
        IRequestHandler<GetCourseByIdQuery, Response<GetCourseResponse>>,
        IRequestHandler<GetCourseListQuery, Response<IList<GetCourseResponse>>>
    {
        private readonly ICourseService _courseService;
        private readonly IMapper _mapper;
        public CourseHandler(ICourseService courseService,IMapper mapper)
        {
            _courseService = courseService;
            _mapper = mapper;
        }
        public async Task<Response<GetCourseResponse>> Handle(GetCourseByIdQuery getCourseByIdRequest, CancellationToken cancellationToken)
        {
            var course = await _courseService.GetCourseByIdAsync(getCourseByIdRequest.id);
            if (course == null)
            {
                throw new EntityNotFoundException(nameof(course), getCourseByIdRequest.id);
            }
            var courseResponseMapped= _mapper.Map<GetCourseResponse>(course);
            return Success(courseResponseMapped);
        }

        public async Task<Response<IList<GetCourseResponse>>> Handle(GetCourseListQuery request, CancellationToken cancellationToken)
        {
            var courseList= await _courseService.GetCoursesListAsync();
            var courseListMapped = _mapper.Map<IList<Course>, IList<GetCourseResponse>>(courseList);
            return Success(courseListMapped);
        }
    }
}
