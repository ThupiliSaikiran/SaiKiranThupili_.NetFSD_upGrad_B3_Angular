namespace ConsoleApp8
{


    public record Student(int RollNumber, string Name, string Course, int Marks);

    class Program
    {
        static void Main()
        {
            Console.Write("Enter number of students: ");
            int n = int.Parse(Console.ReadLine());  

            Student[]  students= new Student[n];    

            for(int i=0; i<n; i++)
            {
                Console.Write("Enter Roll Number: ");
                int rollNumber = int.Parse(Console.ReadLine());

                Console.Write("Enter Name: ");
                string name = Console.ReadLine();

                Console.Write("Enter Course: ");
                string course = Console.ReadLine();

                Console.Write("Enter Marks: ");
                int marks = int.Parse(Console.ReadLine());

                students.Add(new Student(rollNumber, name, course, marks));

               

            }

            Console.Write("Search Roll Number: ");
            int searchRoll = int.Parse(Console.ReadLine());

            Console.WriteLine("\n Student Records: ");
            foreach (var std in students)
            {
                Console.WriteLine($"Roll No: {std.RollNumber} | Name: {std.Name} | Course: {std.Course} | Marks: {std.Marks}");

          

            }
            Console.WriteLine("\n Search Result: ");

            for (int i=0; i< students.Count;i++)
            {
                if (students[i].RollNumber == searchRoll)
                {
                    Console.WriteLine("Student Found: ");
                   Console.WriteLine($"Roll No: {students[i].RollNumber} | Name: {students[i].Name} | Course: {students[i].Course} | Marks: {students[i].Marks}");
                    return;
                }

                if(i==students.Count-1)
                    Console.WriteLine("Student not Found:");
            }





                Console.ReadLine();
        }
    }

}
