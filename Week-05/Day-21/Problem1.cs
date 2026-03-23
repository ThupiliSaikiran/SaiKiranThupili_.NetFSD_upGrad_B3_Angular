namespace ConsoleApp7
{
    class BankAccount
    {
        private int accountNumber;
        private decimal balance;

        public int AccountNumber
        {
            get { return accountNumber; }
        }

        public decimal Balance
        {
            get { return balance; }
        }

        public BankAccount(int accountNumber)
        {
            this.accountNumber = accountNumber;
            balance = 0;
        }

        public void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Deposit amount must be positive!");
                return;
            }

            balance += amount;

            Console.WriteLine($"Deposit successful! Current Balance = {balance}");
        }

        public void Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Withdrawal amount must be positive!");
                return;
            }

            if (amount > balance)
            {
                Console.WriteLine("Insufficient Balance!");
                return;
            }

            balance -= amount;

            Console.WriteLine($"Withdrawal successful! Current Balance = {balance}");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            BankAccount b1 = new BankAccount(101);

            Console.Write("Deposit = ");
            decimal depositAmount = decimal.Parse(Console.ReadLine());
            b1.Deposit(depositAmount);

            Console.Write("Withdraw = ");
            decimal withdrawAmount = decimal.Parse(Console.ReadLine());
            b1.Withdraw(withdrawAmount);

            Console.WriteLine($"Current Balance = {b1.Balance}");
        }
    }
}