using System.IO;
using System.Reflection;

namespace ConsoleApp5
{
    class Program
    {
        static (double sales, int rating) getData(double sales, int rating)
        {
            return (sales, rating);
        }

        static void Main()
        {

            Console.Write("Enter Emp Name: ");
            string name = Console.ReadLine();

            Console.Write("Monthly Sales Amount: ");
            double sales = double.Parse(Console.ReadLine());

            Console.Write("Customer Feedback Rating (1–5): ");
            int rating = int.Parse(Console.ReadLine());

            var data = getData(sales, rating);

            string category = data switch
            {
                ( >= 100000, >= 4) => "High Performer ",
                ( >= 50000, >= 3) => "Average Performer",

                _ => "Need Improvement"

            };

            Console.WriteLine("Employee Name: " + name);
            Console.WriteLine("Monthly Sales Amount: "+sales);
            Console.WriteLine("Rating: "+rating);
            Console.WriteLine("Performance: " + category);













        }
    }

}
