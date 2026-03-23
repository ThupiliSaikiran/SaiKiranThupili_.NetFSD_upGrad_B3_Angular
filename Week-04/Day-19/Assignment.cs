using System;

namespace ConsoleApp35
{
    class Product
    {
        private int _productId;
        private string _productName;
        private double _unitPrice;
        private int _quantity;

        public Product(int id)
        {
            _productId = id;
        }

        public int ProductId
        {
            get { return _productId; } 
        }

        public string ProductName
        {
            get { return _productName; }
            set { _productName = value; }
        }
        public double UnitPrice
        {
            get { return _unitPrice; }
            set { _unitPrice = value; }
        }
        public int Quantity
        {
            get { return _quantity; }   
            set { _quantity = value; }
        }

        public void showDetails()
        {
            double total = _unitPrice * _quantity;

            Console.WriteLine($"Product ID: {_productId}");
            Console.WriteLine($"Product Name: {_productName}");
            Console.WriteLine($"Unit Price: {_unitPrice}");
            Console.WriteLine($"Quantity: {_quantity}");
            Console.WriteLine($"Total: {total}");
        }
    }
    internal class Program
    {

        
        static void Main(string[] args)
        {
            Product p = new Product(101);

            p.ProductName = "Scott";
            p.UnitPrice = 10000;
            p.Quantity = 3;

            p.showDetails();

            Console.ReadLine();
      }
    }
}