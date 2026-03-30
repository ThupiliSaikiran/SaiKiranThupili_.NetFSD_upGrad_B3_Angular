using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Reflection.Metadata;



namespace ConsoleApp
{
   
    class Program
    {

        interface IDiscountStrategy
        {
            double CalculateDiscount(double amount);
        }
        class RegularCustomerDiscount : IDiscountStrategy
        {
            public double CalculateDiscount(double amount)
            {
                int discountPercentage = 10;
                return amount - (amount * (discountPercentage / 100.0));

            }
        }

        class PremiumCustomerDiscount : IDiscountStrategy
        {
            public double CalculateDiscount(double amount)
            {
                int discountPercentage = 20;
                return amount - (amount * (discountPercentage / 100.0));

            }
        }

        class VipCustomerDiscount : IDiscountStrategy
        {
            public double CalculateDiscount(double amount)
            {
                int discountPercentage = 30;
                return amount - (amount * (discountPercentage / 100.0));

            }
        }

        class DiscountService
        {
            private readonly IDiscountStrategy _discount;

            public DiscountService(IDiscountStrategy discount)
            {
                _discount = discount;
            }

            public double PriceCalculator( double amount)
            {
                return _discount.CalculateDiscount(amount);
            }
        }




        public  static void Main()
        {
            DiscountService ds = new DiscountService(new RegularCustomerDiscount());

            double finalPrice = ds.PriceCalculator(100);
            Console.WriteLine("Final Price: " + finalPrice);

          




        }


    }
}