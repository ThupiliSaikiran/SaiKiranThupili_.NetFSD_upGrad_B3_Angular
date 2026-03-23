using System;

namespace ConsoleApp35
{
    class Student
    {
        public double CalculateAverage(int m1, int m2, int m3)
        {
            return (m1 + m2 + m3) / 3;
        }

        public void ShowGrade(double avg)
        {
            string grade;
            switch (avg)
            {
                case >= 80 and <= 100:
                    grade = "A";
                    break;

                case >= 60 and < 80:
                    grade = "B";
                    break;

                case >= 50 and < 60:
                    grade = "C";
                    break;

                case >= 40 and < 50:
                    grade = "D";
                    break;

                default:
                    grade = "Fail";
                    break;
            }

            Console.WriteLine($"Average = {avg}, Grade = {grade}");

        }
    }
    internal class Program
    {

        
        static void Main(string[] args)
        {

            Student s = new Student();
            Console.Write("Enter Marks: ");
            string input = Console.ReadLine();
            string[] parts = input.Split(' ');
            int m1 = int.Parse(parts[0]);
            int m2 = int.Parse(parts[1]);
            int m3 = int.Parse(parts[2]);
            s.ShowGrade(s.CalculateAverage(m1, m2, m3));



            Console.ReadLine();
      }
    }
}