using GBGTechnicalTask.Core.Features.Courses.Commands.Models;
using GBGTechnicalTask.Core.Features.Courses.Queries.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GBGTechnicalTask.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : AppControllerBase
    {
        private readonly IMediator _mediator;
        public CourseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourseById(int id)
        {
            var response= await _mediator.Send(new GetCourseByIdQuery{ id=id });
            return Response(response);
        }

        [HttpGet(nameof(GetCourseList))]
        public async Task<IActionResult> GetCourseList()
        {
            var response = await _mediator.Send(new GetCourseListQuery());
            return Response(response);
        }

        [HttpPost()]
        public async Task<IActionResult> AddStudent([FromBody] AddCourseCommand course)
        {
            var response = await _mediator.Send(course);
            return Response(response);
        }
    }
}
