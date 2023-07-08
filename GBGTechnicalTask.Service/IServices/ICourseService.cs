using GBGTechnicalTask.Data.Entities;
using System.Collections.Generic;

namespace GBGTechnicalTask.Service.IServices
{
    public interface ICourseService
    {
        Task<Course> GetCourseByIdAsync(int id);
        Task<IList<Course>> GetCoursesListAsync();
        Task<Course> AddCourseAsync(Course course);
        Task<bool> IsCourseNameExist(string courseName);
    }
}
