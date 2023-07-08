using GBGTechnicalTask.Data.Entities;

namespace GBGTechnicalTask.Service.IServices
{
    public interface IEnrollmentService
    {
        Task<Enrollment> RegisterStudentToCourse(Enrollment enrollment);
        Task<bool> IsStudentAlreadyRegisteredToTheCourse(Enrollment enrollment);
    }
}
