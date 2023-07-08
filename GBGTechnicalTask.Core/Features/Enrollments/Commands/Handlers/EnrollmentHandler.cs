using AutoMapper;
using GBGTechnicalTask.Core.Bases.Response;
using GBGTechnicalTask.Core.Features.Enrollments.Commands.Models;
using GBGTechnicalTask.Core.Features.Enrollments.Commands.Responses;
using GBGTechnicalTask.Data.Entities;
using GBGTechnicalTask.Service.IServices;
using MediatR;

namespace GBGTechnicalTask.Core.Features.Enrollments.Commands.Handlers
{
    public class EnrollmentHandler : 
        ResponseHandler,
        IRequestHandler<AddEnrollmentCommand, Response<AddEnrollmentResponse>>
    {
        private readonly IEnrollmentService _enrollmentService;
        private readonly IMapper _mapper;

        public EnrollmentHandler(
              IEnrollmentService enrollmentService
            , IMapper mapper)
        {
            _enrollmentService = enrollmentService;
            _mapper = mapper;
        }

        public async Task<Response<AddEnrollmentResponse>> Handle(AddEnrollmentCommand request, CancellationToken cancellationToken)
        {
            var enrollmentMapped = _mapper.Map<Enrollment>(request);
            var enrollmentEntity = await _enrollmentService.RegisterStudentToCourse(enrollmentMapped);
            var enrollmentResponseMapped= _mapper.Map<Enrollment, AddEnrollmentResponse>(enrollmentEntity);
            return Created(enrollmentResponseMapped);
        }
    }
}
