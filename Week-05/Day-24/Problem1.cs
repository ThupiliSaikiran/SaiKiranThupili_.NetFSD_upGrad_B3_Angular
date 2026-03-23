using System.IO;

namespace ConsoleApp5
{
    class Program
    {
        static void Main()
        {
            string dirName = "Logs";

            if (Directory.Exists(dirName) == false)
            {
                Directory.CreateDirectory(dirName);
            }
            string logFilePath = Path.Combine(dirName, "activity_log.txt");

           


            while (true)
            {
                Console.WriteLine("Opt to select :");
                Console.WriteLine("1. Add message ");
                Console.WriteLine("2. show message");
                Console.Write("Choose your Option: ");
                int opt = int.Parse(Console.ReadLine());

                if(opt == 1)
                {
                    StreamWriter sw = new StreamWriter(logFilePath, true);
                    Console.Write("Enter Your message: ");
                    string input = Console.ReadLine();

                    sw.WriteLine(input);
                    sw.Close();

                }else if(opt == 2)
                {
                    StreamReader sr = new StreamReader(logFilePath);

                    Console.WriteLine("-----------------------------------------");
                    while (sr.EndOfStream == false)
                    {
                        Console.WriteLine(sr.ReadLine());
                    }
                }
                else
                {
                    return;
                }

            }

           




        }
    }

}
