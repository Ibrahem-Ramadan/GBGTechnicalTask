using GBGTechnicalTask.Data.Entities;
using GBGTechnicalTask.Infrastructure.Data;
using GBGTechnicalTask.Infrastructure.InfrastructureBases;
using GBGTechnicalTask.Infrastructure.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBGTechnicalTask.Infrastructure.Repositories
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        private readonly DbSet<Student> _students;
        public StudentRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _students = appDbContext.Set<Student>();
        }
    }
}
