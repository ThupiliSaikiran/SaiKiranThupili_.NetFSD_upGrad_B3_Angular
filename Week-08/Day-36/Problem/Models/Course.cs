namespace WebApplication3.Models
{
    public class Course
    {
        public int Courseid {  get; set; }

        public string CourseName { get; set; }

        public ICollection<Student> Students {  get; set; }
    }
}
