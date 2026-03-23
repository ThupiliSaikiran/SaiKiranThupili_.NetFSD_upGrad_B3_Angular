namespace ConsoleApp7
{
    class Employee
    {
        public string Name {  get; set; }
        public decimal BaseSalary {  get; set; }

        public virtual decimal CalculateSalary()
        {
            return BaseSalary;
        }
    }

    class Manager : Employee
    {
        public override decimal CalculateSalary()
        {
            return BaseSalary + (BaseSalary * 0.20m);
        }
    }

    class Developer : Employee
    {
        public override decimal CalculateSalary()
        {
            return BaseSalary + (BaseSalary * 0.10m);

        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Employee emp = new Employee();
            Console.Write("Base Salary = ");
            decimal baseSalary = decimal.Parse(Console.ReadLine());
            emp.BaseSalary= baseSalary;

            Manager manager = new Manager();
            Developer developer = new Developer();
            manager.BaseSalary = baseSalary;
            developer.BaseSalary = baseSalary;

            Console.WriteLine($"Manager Salary = {manager.CalculateSalary()}, Developer Salary = {developer.CalculateSalary()}");

        }
    }
}