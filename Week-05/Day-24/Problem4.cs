using System;
using System.IO;
using System.Threading.Tasks;
using System.Net.Http;
using System.Diagnostics;



namespace ConsoleApp
{
    class Employee
    {
        public int empId {  get; set; }
        public string name {  get; set; }

        public Employee(int empId, string name)
        {
            this.empId = empId;
            this.name = name;
        }
    }
    class Program
    {

        
        public  static void Main()
        {
            LinkedList<Employee> list = new LinkedList<Employee>();

            Console.Write("Insert: ");
            string emps = Console.ReadLine();

            string[] employees = emps.Split(",");

            foreach (string employee in employees)
            {
                string[] data = employee.Trim().Split(" ");
                int empId = int.Parse(data[0]);
                string name = data[1];

                list.AddLast(new Employee(empId, name));
            }

          
            Console.Write("Delete: ");
            int deleteId = int.Parse(Console.ReadLine());

            var current = list.First;

           while(current != null)
            {
                var nextNode = current.Next; // store next node

                if (current.Value.empId == deleteId)
                {
                    list.Remove(current);
                }

                current = nextNode;
            }

           foreach (Employee emp in list)
            {
                Console.Write(emp.empId+" "+emp.name);
            }

        }




    }
}