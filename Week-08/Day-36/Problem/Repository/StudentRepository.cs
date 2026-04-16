using Dapper;
using Microsoft.Data.SqlClient;
using System.Reflection;
using WebApplication3.Models;

namespace WebApplication3.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly string _conStr;

        public StudentRepository(IConfiguration config)
        {
            _conStr = config.GetConnectionString("DefaultConnection");
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_conStr);
        }

        public IEnumerable<Student> GetStudnetsWithcourse()
        {

            using (var db  = GetConnection())
            {

                string sqlQuery =

                "SELECT s.StudentId, s.StudentName, s.CourseId,c.CourseId, c.CourseName FROM Students s INNER JOIN Courses c ON s.CourseId = c.CourseId";

                return db.Query<Student, Course, Student>(
                    sqlQuery,
                    (std, course) =>
                    {
                        std.Course = course;
                        return std;
                    },
                    splitOn: "CourseId"
                    );
            }
        }
        public IEnumerable<Course> GetCoursesWithStudnets()
        {
            using (var db = GetConnection())
            {


                string sqlQuery = "SELECT c.CourseId, c.CourseName,s.StudentId, s.StudentName, s.CourseId FROM Courses c LEFT JOIN Students s ON s.CourseId = c.CourseId";

                var dictObj = new Dictionary<int, Course>();

                var list = db.Query<Course, Student, Course>(
                    sqlQuery,
                    (course, std) =>
                    {
                        if (!dictObj.TryGetValue(course.Courseid, out var currCourse))
                        {
                            currCourse = course;
                            currCourse.Students = new List<Student>();
                            dictObj.Add(currCourse.Courseid, currCourse);
                        }
                        if (std != null)
                        {
                            currCourse.Students.Add(std);
                        }
                        return course;
                    },
                    splitOn: "StudentId"

                    );
                return dictObj.Values;
            }
        }
    }
}
