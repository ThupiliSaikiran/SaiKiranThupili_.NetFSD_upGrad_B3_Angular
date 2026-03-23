namespace ConsoleApp8
{



  
    class Calculator
    {
        public void Divide(int numerator, int denominator)
        {
            try
            {
                double result = numerator / denominator;
                Console.WriteLine($"Result : {result}");
            }
            catch(DivideByZeroException ex) {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                Console.WriteLine("Operation completed safely");
            }
        }
    }

    class Program
    {
        static void Main()
        {
           Calculator c = new Calculator();
            Console.Write("Numerator = ");
            int numerator = int.Parse( Console.ReadLine() );
            Console.Write("Denominator = ");
            int denominator = int.Parse(Console.ReadLine());

            c.Divide(numerator, denominator);

        }
    }

}
