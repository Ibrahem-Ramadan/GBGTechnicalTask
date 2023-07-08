using GBGTechnicalTask.Core.Features.Enrollments.Commands.Models;
using GBGTechnicalTask.Core.Features.Students.Commands.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GBGTechnicalTask.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentController : AppControllerBase
    {
        private readonly IMediator _mediator;
        public EnrollmentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost()]
        public async Task<IActionResult> RegisterStudentToCourse([FromBody] AddEnrollmentCommand enrollment)
        {
            var response = await _mediator.Send(enrollment);
            return Response(response);
        }
    }
}
