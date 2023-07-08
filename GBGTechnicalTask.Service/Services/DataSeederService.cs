using GBGTechnicalTask.Data.Entities;
using GBGTechnicalTask.Infrastructure.IRepositories;
using GBGTechnicalTask.Service.IServices;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace GBGTechnicalTask.Service.Services
{
    public class DataSeederService : IDataSeederService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly ILogger<DataSeederService> _logger;
        public DataSeederService(IStudentRepository studentRepository,ICourseRepository courseRepository, ILogger<DataSeederService> logger)
        {
            _studentRepository = studentRepository;
            _courseRepository = courseRepository;
            _logger = logger;
        }
        public async Task SeedData()
        {   
            _logger.LogInformation("Seeding Data ...");
            if(!_studentRepository.GetTableAsTracking().Result.Any())
            {
                await _studentRepository.AddRangeAsync(ReadDataFromFile<Student>());
            }
            if(!_courseRepository.GetTableAsTracking().Result.Any())
            {
                await _courseRepository.AddRangeAsync(ReadDataFromFile<Course>());
            }
        }
        private static IEnumerable<T> ReadDataFromFile<T>()
        {
            var slnDir = Directory.GetParent(Directory.GetCurrentDirectory());
            var infraDir = slnDir!.GetDirectories().Where(x=>x.Extension == ".Infrastructure").FirstOrDefault();
            if (infraDir != null)
            {
                var path = Path.Combine($"{infraDir.FullName}\\DataSeed\\{typeof(T).Name}.json");
                //_logger.LogDebug(file);
                if(!String.IsNullOrEmpty(path))
                {
                    using (var streamReader = new StreamReader(path))
                    {
                        var json= streamReader.ReadToEnd();
                        return JsonSerializer.Deserialize<IEnumerable<T>>(json);
                    }
                }
            }
            return Enumerable.Empty<T>();
        }
    }
}
