using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Reflection.Metadata;



namespace ConsoleApp
{
   
    class Program
    {

        class Student
        {
            public int StudentId { get; set; } 
            public string StudentName { get; set; }

            public int Marks { get; set; }

            public Student(int studentId, string studentName, int marks)
            {
                StudentId = studentId;
                StudentName = studentName;
                Marks = marks;
            }
        }

        class StudentRepository
        {
            List<Student> students = new List<Student>();

            public void Save(Student student)
            {
                students.Add(student);
                Console.WriteLine("Student added successfully!!");
            }
            public List<Student> GetAll()
            {
                return students; 
            }
        }

        class ReportGenerator
        {
           
            public void ShowReport(List<Student> students)
            {
                Console.WriteLine("======= Report =======");
                foreach(var  student in students)
                {
                    Console.WriteLine($"Stundent Id: {student.StudentId}");
                    Console.WriteLine($"Stundent Name: {student.StudentName}");
                    Console.WriteLine($"Marks: {student.Marks}");

                }
                Console.WriteLine("====================================");
               


            }

            
        }


        public  static void Main()
        {

            StudentRepository sr = new StudentRepository();
            ReportGenerator rg = new ReportGenerator();

            Student s1 = new Student(101, "Saikiran", 89);
            Student s2 = new Student(102, "Pawan Kalyan", 80);

            sr.Save(s1);
            sr.Save(s2);

            var students = sr.GetAll();

            rg.ShowReport(students);
        }


    }
}