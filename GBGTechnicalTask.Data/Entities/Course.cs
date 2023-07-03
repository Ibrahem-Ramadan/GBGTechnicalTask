namespace GBGTechnicalTask.Data.Entities
{
    public class Course
    {
        public Course()   
        {
            Students = new List<Student>();
        }
        public int Id { get; set; }
        public string? Name { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
