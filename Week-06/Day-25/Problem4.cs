using System;
using System.IO;
using System.Threading.Tasks;
using System.Net.Http;
using System.Diagnostics;



namespace ConsoleApp
{
    class Program
    {


        public static async Task VerifyPaymentAsync()

        {
            Console.WriteLine("Payment started..");
            await Task.Delay(2000);
            Console.WriteLine("Payment Ended..");

        }

        public static async Task CheckInventoryAsync()
        {
            Console.WriteLine("Inventory report started..");
            await Task.Delay(2000);
            Console.WriteLine("Inventory report Ended..");

        }

        public static async Task ConfirmOrderAsync()
        {
            Console.WriteLine("Customer report started..");
             await Task.Delay(2000);
            Console.WriteLine("Customer report Ended..");

        }



        public async static Task Main()
        {

            await VerifyPaymentAsync();
            await CheckInventoryAsync();
            await ConfirmOrderAsync();


        }

        

        
    }
}