using AutoMapper;
using GBGTechnicalTask.Core.Bases.Response;
using GBGTechnicalTask.Core.Features.Students.Commands.Models;
using GBGTechnicalTask.Core.Features.Students.Commands.Responses;
using GBGTechnicalTask.Data.Entities;
using GBGTechnicalTask.Service.IServices;
using MediatR;

namespace GBGTechnicalTask.Core.Features.Students.Commands.Handlers
{
    public class StudentHandler : 
        ResponseHandler,
        IRequestHandler<AddStudentCommand, Response<AddStudentResponse>>
    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;

        public StudentHandler(
              IStudentService studentService
            , IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
        }
        public async Task<Response<AddStudentResponse>> Handle(AddStudentCommand request, CancellationToken cancellationToken)
        {
            var addStudentCommandMapped= _mapper.Map<AddStudentCommand,Student>(request);
            var studentEntity= await _studentService.AddStudentAsync(addStudentCommandMapped);
            var addStudentResponseMapped = _mapper.Map<Student, AddStudentResponse>(studentEntity);
            return Created(addStudentResponseMapped);
        }
    }
}
