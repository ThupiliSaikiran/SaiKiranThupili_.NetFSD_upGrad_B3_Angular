using System;

namespace ConsoleApp35
{
    class Calculator
    {

        public int Add(int a, int b)
        {
            return a + b;
        }
        public int Subtract(int a, int b)
        {
            return a - b;
        }
    }
    internal class Program
    {

        
        static void Main(string[] args)
        {
            Calculator c = new Calculator();

            Console.Write("Enter Numbers: ");
            string input  = Console.ReadLine();
            string[] nums = input.Split(' ');
            int a =int.Parse(nums[0]);
            int b = int.Parse(nums[1]);


            Console.WriteLine("Addition = " + c.Add(a, b));
            Console.WriteLine("Subtraction = " + c.Subtract(a, b));



            Console.ReadLine();
      }
    }
}