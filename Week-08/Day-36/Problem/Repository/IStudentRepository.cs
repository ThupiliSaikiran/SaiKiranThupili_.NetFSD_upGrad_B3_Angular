using WebApplication3.Models;

namespace WebApplication3.Repository
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetStudnetsWithcourse();
        IEnumerable<Course> GetCoursesWithStudnets();
    }
}
