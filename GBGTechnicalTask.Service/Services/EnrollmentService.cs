using GBGTechnicalTask.Data.Entities;
using GBGTechnicalTask.Infrastructure.IRepositories;
using GBGTechnicalTask.Service.IServices;

namespace GBGTechnicalTask.Service.Services
{
    public class EnrollmentService : IEnrollmentService
    {
        private readonly IEnrollmentRepository _enrollmentRepository;
        public EnrollmentService(IEnrollmentRepository enrollmentRepository)
        {
            _enrollmentRepository = enrollmentRepository;
        }

        public async Task<bool> IsStudentAlreadyRegisteredToTheCourse(Enrollment enrollment)
        {
            var enrollments = await _enrollmentRepository.GetTableAsNoTracking();
            var enrollmentExists= enrollments.FirstOrDefault(e=>e.CourseId == enrollment.CourseId && e.StudentId == enrollment.StudentId);
            return enrollmentExists != null;
        }

        public async Task<Enrollment> RegisterStudentToCourse(Enrollment enrollment)
        {
            return await _enrollmentRepository.AddAsync(enrollment);
        }
    }
}
