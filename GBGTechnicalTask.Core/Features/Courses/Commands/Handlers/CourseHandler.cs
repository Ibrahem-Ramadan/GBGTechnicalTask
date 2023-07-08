using AutoMapper;
using GBGTechnicalTask.Core.Bases.Response;
using GBGTechnicalTask.Core.Features.Courses.Commands.Models;
using GBGTechnicalTask.Core.Features.Courses.Commands.Responses;
using GBGTechnicalTask.Data.Entities;
using GBGTechnicalTask.Service.IServices;
using MediatR;

namespace GBGTechnicalTask.Core.Features.Courses.Commands.Handlers
{
    public class CourseHandler :
        ResponseHandler,
        IRequestHandler<AddCourseCommand, Response<AddCourseResponse>>
    {
        private readonly ICourseService _courseService;
        private readonly IMapper _mapper;

        public CourseHandler(
              ICourseService courseService
            , IMapper mapper)
        {
            _courseService = courseService;
            _mapper = mapper;
        }
        public async Task<Response<AddCourseResponse>> Handle(AddCourseCommand request, CancellationToken cancellationToken)
        {
            var courseEntityMapped= _mapper.Map<AddCourseCommand, Course>(request);
            var courseAdded= await _courseService.AddCourseAsync(courseEntityMapped);
            var courseResponseMapped = _mapper.Map<Course, AddCourseResponse>(courseAdded);
            return Created(courseResponseMapped);
        }
    }
}
