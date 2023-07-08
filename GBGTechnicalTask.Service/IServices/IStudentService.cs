using GBGTechnicalTask.Data.Entities;

namespace GBGTechnicalTask.Service.IServices
{
    public interface IStudentService
    {
        Task<Student> AddStudentAsync(Student student);
        Task<Student> GetStudentByIdAsync(int id);
        Task<IList<Student>> GetStudentsListAsync();
        Task<bool> IsStudentNameExist(string studentName);
    }
}
