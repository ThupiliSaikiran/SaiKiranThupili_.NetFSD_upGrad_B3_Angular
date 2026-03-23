using System.IO;
using System.Reflection;

namespace ConsoleApp5
{
    class Program
    {
        static void Main()
        {


            string folderPath = "C:\\CSharp\\Day24";

            if (!Directory.Exists(folderPath))
            {
                Console.WriteLine("Invalid directory path!");
                return;
            }

            DirectoryInfo dio = new DirectoryInfo(folderPath);

            if(dio.GetFiles().Length == 0 )
            {
                Console.WriteLine("No files found in the directory.");
                return;
            }

            int count =0;
            foreach (FileInfo fi in dio.GetFiles())
            {

                Console.WriteLine("File Name: " + fi.Name);

                Console.WriteLine("File Full Name: " + fi.FullName);

                Console.WriteLine("File Size: " + fi.Length);

                Console.WriteLine("Created date: " + fi.CreationTime.ToString("dd-MM-yyyy"));

                Console.WriteLine("----------------------------------------");

                count++;


            }

            Console.WriteLine("Total files Count: " + count);





        }
    }

}
