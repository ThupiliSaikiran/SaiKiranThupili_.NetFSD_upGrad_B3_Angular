namespace ConsoleApp7
{
    class Product
    {
        public string Name { get; set; }

        private double price;
        public double Price
        {
            get {  return price; }
            set
            {
                if(value >= 0) price = value;
            }

        }
        public Product(string name, double price)
        {
            Name = name;
            Price = price;

        }

        public virtual void CalculateDiscount()
        {
            Console.WriteLine($"Price = {Price}");
        }


    }

    class Electronics : Product
    {
        public Electronics(string name,double price) : base(name, price)
        {
        }

        public override void CalculateDiscount()
        {
            Console.WriteLine($"Final Price after 5% discount = {Price - (Price * 0.05)}");
        }
    }
    class Clothing : Product
    {
        public Clothing(string name, double price) : base(name,price)
        {
        }

        public override void CalculateDiscount()
        {
            Console.WriteLine($"Final Price after 15% discount = {Price - (Price * 0.15)}");
        }
    }



    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Electronics Price = ");
            double electronicPrice = double.Parse(Console.ReadLine());
            Product e = new Electronics("Mobile",electronicPrice);
            e.CalculateDiscount();



        }
    }
}