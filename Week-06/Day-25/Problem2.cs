using System;
using System.IO;
using System.Threading.Tasks;
using System.Net.Http;
using System.Diagnostics;



namespace ConsoleApp
{
    class Program
    {

       
        public static void Main()
        {
            Console.Write("Product Name: ");
            string name = Console.ReadLine();

            Console.Write("Product Price: ");
            double price = double.Parse(Console.ReadLine());

            Console.Write("Discount Percentage: ");
            int discountPercent = int.Parse(Console.ReadLine());


            double finalPrice =price -(price * discountPercent/100);

            Console.WriteLine(finalPrice);



        }

        

        
    }
}