using GBGTechnicalTask.Data.Entities;

namespace GBGTechnicalTask.Service.IServices
{
    public interface IStudentService
    {
        Task<Student> AddStudentAsync(Student student);
    }
}
