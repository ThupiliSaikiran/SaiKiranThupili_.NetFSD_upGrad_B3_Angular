using System;
using System.IO;
using System.Threading.Tasks;
using System.Net.Http;
using System.Diagnostics;



namespace ConsoleApp
{
    class Program
    {

        static async Task WriteLogAsync(string message)
        {


            Console.WriteLine($"Starting : {message}");
            await Task.Delay(1000);

            using( StreamWriter sw = new StreamWriter("test.txt")
            {
                sw.WriteLine(message)
            })
            Console.WriteLine($"Ending : {message}");


        }
        public async  static Task Main()
        {
            Task log1 = WriteLogAsync("User logged in");
            Task log2 = WriteLogAsync("File uploaded");
            Task log3 = WriteLogAsync("Error occurred");

            await Task.WhenAll(log1, log2, log3);

            Console.WriteLine("All logs Completed..");


            Console.ReadLine();

        }

        

        
    }
}