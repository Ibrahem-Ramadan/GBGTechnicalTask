﻿using GBGTechnicalTask.Data.Entities;
using GBGTechnicalTask.Infrastructure.IRepositories;
using GBGTechnicalTask.Infrastructure.Repositories;
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

        public async Task<Student> GetStudentByIdAsync(int id)
        {
            var student = await _studentRepository.GetByIdAsync(id);
            return student;
        }
        public async Task<IList<Student>> GetStudentsListAsync()
        {
            var students = await _studentRepository.GetTableAsTracking();
            return students;
        }

        public async Task<bool> IsStudentNameExist(string studentName)
        {
            var students= await _studentRepository.GetTableAsNoTracking();
            var studentNameExists= students.FirstOrDefault(student => student.Name==studentName);
            return studentNameExists != null;
        }
    }
}
