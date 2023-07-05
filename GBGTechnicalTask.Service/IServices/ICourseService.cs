using GBGTechnicalTask.Data.Entities;

namespace GBGTechnicalTask.Service.IServices
{
    public interface ICourseService
    {
        Task<Course> GetCourseByIdAsync(int id);
    }
}
