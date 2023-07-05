using GBGTechnicalTask.Data.Entities;
using GBGTechnicalTask.Infrastructure.IRepositories;
using GBGTechnicalTask.Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBGTechnicalTask.Service.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        public StudentService(IStudentRepository studentRepository) {
            _studentRepository=studentRepository;
        }
        public async Task<Student> AddStudentAsync(Student student)
        {
            return await _studentRepository.AddAsync(student);
        }
    }
}
