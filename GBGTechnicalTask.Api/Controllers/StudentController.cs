using GBGTechnicalTask.Core.Features.Students.Commands.Models;
using GBGTechnicalTask.Data.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GBGTechnicalTask.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IMediator _mediator;
        public StudentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost()]
        public async Task<IActionResult> AddStudent([FromBody]AddStudentCommand student)
        {
            var response = await _mediator.Send(student);
            return Ok(response);
        }
    }
}
