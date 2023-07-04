using GBGTechnicalTask.Core.Features.Courses.Queries.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GBGTechnicalTask.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
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
            return Ok(response);
        }
    }
}
