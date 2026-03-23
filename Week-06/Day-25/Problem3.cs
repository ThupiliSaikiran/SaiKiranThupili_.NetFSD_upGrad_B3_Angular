using System;
using System.IO;
using System.Threading.Tasks;
using System.Net.Http;
using System.Diagnostics;



namespace ConsoleApp
{
    class Program
    {
        public static void GenerateSalesReport()
        {
            Console.WriteLine("Sales report started..");
            Task.Delay(3000).Wait();
            Console.WriteLine("Sales report Ended..");

        }

        public static void GenerateInventoryReport()
        {
            Console.WriteLine("Inventory report started..");
            Task.Delay(4000).Wait();
            Console.WriteLine("Inventory report Ended..");

        }

        public static void GenerateCustomerReport()
        {
            Console.WriteLine("Customer report started..");
             Task.Delay(5000).Wait();
            Console.WriteLine("Customer report Ended..");

        }



        public async static Task Main()
        {

            Task t1 = Task.Run(() => GenerateSalesReport());
            Task t2 = Task.Run(() => GenerateInventoryReport());
            Task t3 = Task.Run(() => GenerateCustomerReport());

            await Task.WhenAll(t1, t2, t3);

            Console.WriteLine("All Tasks are Completed");

            Console.ReadLine();


        }

        

        
    }
}