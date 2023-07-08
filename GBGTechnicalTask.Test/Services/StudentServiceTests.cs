using GBGTechnicalTask.Data.Entities;
using GBGTechnicalTask.Infrastructure.IRepositories;
using GBGTechnicalTask.Service.IServices;
using GBGTechnicalTask.Service.Services;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace GBGTechnicalTask.Test.Services
{
    public class StudentServiceTests
    {
        private readonly Mock<IStudentRepository> _studentRepositoryMock;
        private readonly IStudentService _studentService;

        public StudentServiceTests()
        {
            _studentRepositoryMock = new Mock<IStudentRepository>();
            _studentService = new StudentService(_studentRepositoryMock.Object);
        }

        [Fact]
        public async Task ItShouldReturnsNewStudent_WhenAddNewStudent()
        {
            // Arrange
            var newStudent = new Student { Name="Student_1025555"};
            _studentRepositoryMock.Setup(m => m.AddAsync(newStudent)).ReturnsAsync(newStudent);

            // Act
            var result = await _studentService.AddStudentAsync(newStudent);

            // Assert
            Assert.Equal(newStudent, result);
        }

        [Fact]
        public async Task ItShouldReturnsStudentWithRequestedId_WhenGetStudentById()
        {
            // Arrange
            var studentId = 1;
            var expectedStudent = new Student { Id = studentId, Name="Student 1" };
            _studentRepositoryMock.Setup(m => m.GetByIdAsync(studentId)).ReturnsAsync(expectedStudent);

            // Act
            var result = await _studentService.GetStudentByIdAsync(studentId);

            // Assert
            Assert.Equal(expectedStudent, result);
        }

        [Fact]
        public async Task ItShouldReturnsListOfStudents_WhenRequestStudentsList()
        {
            // Arrange
            var expectedStudents = new List<Student> {
                new Student { Id=1,Name="Student 1" },
                new Student { Id=2,Name="Student 2" },
                new Student { Id=3,Name="Student 3" },
            };
            _studentRepositoryMock.Setup(m => m.GetTableAsTracking()).ReturnsAsync(expectedStudents);

            // Act
            var result = await _studentService.GetStudentsListAsync();

            // Assert
            Assert.Equal(expectedStudents, result);
        }

        [Fact]
        public async Task ItShouldReturnsTrue_WhenStudentNameExists()
        {
            // Arrange
            var studentName = "Student_1025555";
            var existingStudent = new Student { Name = studentName };
            var students = new List<Student> { existingStudent };
            _studentRepositoryMock.Setup(m => m.GetTableAsNoTracking()).ReturnsAsync(students.ToList());

            // Act
            var result = await _studentService.IsStudentNameExist(studentName);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task ItShouldReturnsFalse_WhenStudentNameExists()
        {
            // Arrange
            var studentName = "Student_111111";
            var students = new List<Student>();
            _studentRepositoryMock.Setup(m => m.GetTableAsNoTracking()).ReturnsAsync(students.ToList());

            // Act
            var result = await _studentService.IsStudentNameExist(studentName);

            // Assert
            Assert.False(result);
        }
    }
}
