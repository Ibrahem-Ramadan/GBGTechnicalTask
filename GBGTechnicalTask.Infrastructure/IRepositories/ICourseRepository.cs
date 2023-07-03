using GBGTechnicalTask.Data.Entities;

namespace GBGTechnicalTask.Infrastructure.IRepositories
{
    public interface ICourseRepository
    {
        Task<Course> GetByIdAsync(int id);
    }
}
