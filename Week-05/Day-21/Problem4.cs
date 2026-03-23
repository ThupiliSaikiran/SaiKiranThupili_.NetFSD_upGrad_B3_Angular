namespace ConsoleApp7
{
    class Vehicle
    {
        public string Brand { get; set; }

        private double rentalRatePerDay;
        public double RentalRatePerDay
        {
            get {  return rentalRatePerDay; }
            set
            {
                if(value >= 0) rentalRatePerDay = value;
            }

        }
        public Vehicle(string brand, double rentalRatePerDay)
        {
            Brand = brand;
            RentalRatePerDay = rentalRatePerDay;

        }

        public virtual double CalculateRental(int days)
        {
            if (days <= 0)
                throw new ArgumentException("Days must be positive");
            return RentalRatePerDay * days;
        }


    }

    class Car : Vehicle
    {
        public Car(string brand,double rentalRatePerDay) : base(brand, rentalRatePerDay)
        {
        }

        public override double CalculateRental(int days)
        {
            double total = base.CalculateRental(days);
            return total + 500;
        }
    }
    class Bike : Vehicle
    {
        public Bike(string brand, double rentalRatePerDay) : base(brand, rentalRatePerDay)
        {
        }

        public override double CalculateRental(int days)
        {
            double total = base.CalculateRental(days);
            return total - (total*0.05);
        }
    }



    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Car RentalRateDay = ");
            double carReant = double.Parse(Console.ReadLine());
            Console.Write("Days = ");
            int days = int.Parse(Console.ReadLine());
            Vehicle v = new Car("Audi",carReant);
            double carTotal=v.CalculateRental(days);


            Console.WriteLine($"Total Rental = {carTotal}");



        }
    }
}