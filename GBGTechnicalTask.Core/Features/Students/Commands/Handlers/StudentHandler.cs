using AutoMapper;
using GBGTechnicalTask.Core.Features.Students.Commands.Models;
using GBGTechnicalTask.Data.Entities;
using GBGTechnicalTask.Service.IServices;
using MediatR;

namespace GBGTechnicalTask.Core.Features.Students.Commands.Handlers
{
    public class StudentHandler : IRequestHandler<AddStudentCommand, Student>
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
        public Task<Student> Handle(AddStudentCommand request, CancellationToken cancellationToken)
        {
            var studentMapped= _mapper.Map<Student>(request);
            return _studentService.AddStudentAsync(studentMapped);
        }
    }
}
