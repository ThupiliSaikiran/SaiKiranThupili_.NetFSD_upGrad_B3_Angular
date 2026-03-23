namespace ConsoleApp8
{


    public class InsufficientBalanceException : Exception
    {
        public InsufficientBalanceException(string message) : base(message) { }
    }


    class BankAccount
    {
        public double Balance { get; set; }

       

        public void Withdraw(double amount)
        {
            try
            {
                if (amount > Balance)
                {
                    throw new InsufficientBalanceException("Withdrawal amount exceeds available balance !!");
                }
                Balance -= amount;
                Console.WriteLine("Amount Withdraw successfully !!");

            }catch (InsufficientBalanceException ex) {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                Console.WriteLine($"Final Balance: {Balance}");
            }
            
        }
    }

    class Program
    {
        static void Main()
        {
            BankAccount account= new BankAccount();

            Console.Write("Balance = ");
            double balance = int.Parse(Console.ReadLine());
            account.Balance = balance;

            Console.Write("Withdraw = ");
            double withdrawBal = int.Parse(Console.ReadLine());

            account.Withdraw(withdrawBal);



        }
    }

}
