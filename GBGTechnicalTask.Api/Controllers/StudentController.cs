using GBGTechnicalTask.Core.Features.Courses.Queries.Models;
using GBGTechnicalTask.Core.Features.Students.Commands.Models;
using GBGTechnicalTask.Core.Features.Students.Queries.Models;
using GBGTechnicalTask.Data.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GBGTechnicalTask.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController :AppControllerBase
    {
        private readonly IMediator _mediator;
        public StudentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentById(int id)
        {
            var response = await _mediator.Send(new GetStudentByIdQuery{ id = id });
            return Response(response);
        }

        [HttpGet(nameof(GetStudentList))]
        public async Task<IActionResult> GetStudentList()
        {
            var response = await _mediator.Send(new GetStudentListQuery());
            return Response(response);
        }

        [HttpPost()]
        public async Task<IActionResult> AddStudent([FromBody]AddStudentCommand student)
        {
            var response = await _mediator.Send(student);
            return Response(response);
        }
    }
}
