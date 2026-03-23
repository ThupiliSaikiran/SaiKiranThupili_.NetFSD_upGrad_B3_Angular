using System;
using System.IO;
using System.Threading.Tasks;
using System.Net.Http;
using System.Diagnostics;



namespace ConsoleApp
{
    class Program
    {

        
        public  static void Main()
        {
            Stack<string> stack = new Stack<string>();

            string[] actions = Console.ReadLine().Split(",");
            foreach (string action in actions)
            {
                if(action == "Undo")
                {
                    stack.Pop();

                }
                else
                {
                    stack.Push(action);
                }
            }
            Console.WriteLine("Current State after the opeartion: " + stack.Peek());

        }




    }
}