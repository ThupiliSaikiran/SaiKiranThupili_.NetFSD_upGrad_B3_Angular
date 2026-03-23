using System;
using System.IO;
using System.Threading.Tasks;
using System.Net.Http;
using System.Diagnostics;



namespace ConsoleApp
{
    class Program
    {
        public static void validateOrder()
        {
            Trace.TraceInformation("validating Order..");
            Console.WriteLine("validated order");
        }
        public static void processPayment()
        {
            Trace.TraceInformation("processing Payment..");
            Console.WriteLine("processed payment");
        }
        public static void updateInventory()
        {
            Trace.TraceInformation("Updating Inventory..");
            Console.WriteLine("Updated Inventory");
        }
        public static void generateInvoice()
        {
            Trace.TraceInformation("Generating Invoice..");
            Console.WriteLine("Updated Inventory");
        }





        public  static void Main()
        {
            string filePath = "log.txt";

            TextWriterTraceListener traceListener = new TextWriterTraceListener(filePath);
            Trace.Listeners.Add(traceListener);

            Trace.WriteLine("Order Processing started");

            

            validateOrder();
            processPayment();
            updateInventory();
            generateInvoice();

            Trace.WriteLine("Order Processing Completed");

            Trace.Flush();
            Trace.Close();
            






        }

        

        
    }
}