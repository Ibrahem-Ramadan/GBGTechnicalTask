using AutoMapper;
using GBGTechnicalTask.Core.Bases.Response;
using GBGTechnicalTask.Core.Exceptions;
using GBGTechnicalTask.Core.Features.Students.Queries.Models;
using GBGTechnicalTask.Core.Features.Students.Queries.Responses;
using GBGTechnicalTask.Data.Entities;
using GBGTechnicalTask.Service.IServices;
using MediatR;

namespace GBGTechnicalTask.Core.Features.Students.Queries.Handlers
{
    public class StudentHandler :
        ResponseHandler,
        IRequestHandler<GetStudentByIdQuery, Response<GetStudentResponse>>,
        IRequestHandler<GetStudentListQuery, Response<IList<GetStudentResponse>>>
    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;
        public StudentHandler(IStudentService studentService,IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
        }
        public async Task<Response<GetStudentResponse>> Handle(GetStudentByIdQuery getStudentByIdRequest, CancellationToken cancellationToken)
        {
            var student = await _studentService.GetStudentByIdAsync(getStudentByIdRequest.id);
            if (student == null)
            {
                throw new EntityNotFoundException(nameof(student), getStudentByIdRequest.id);
            }
            var studentResponseMapped = _mapper.Map<GetStudentResponse>(student);
            return Success(studentResponseMapped);
        }
        public async Task<Response<IList<GetStudentResponse>>> Handle(GetStudentListQuery request, CancellationToken cancellationToken)
        {
            var studentList = await _studentService.GetStudentsListAsync();
            var studentListMapped = _mapper.Map<IList<Student>, IList<GetStudentResponse>>(studentList);
            return Success(studentListMapped);
        }
    }
}
