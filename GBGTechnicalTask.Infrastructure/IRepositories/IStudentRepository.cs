using GBGTechnicalTask.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBGTechnicalTask.Infrastructure.IRepositories
{
    public interface IStudentRepository
    {
        Task<Student> AddAsync(Student student);
    }
}
