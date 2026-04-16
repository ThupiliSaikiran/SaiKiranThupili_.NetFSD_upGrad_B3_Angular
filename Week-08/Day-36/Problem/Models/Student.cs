using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication3.Models
{
    public class Student
    {
        public int StudentId { get; set; }

        public string StudentName { get; set; }


        [ForeignKey("Course")]
        public int CourseId {  get; set; }

        public Course Course { get; set; }  


    }
}
