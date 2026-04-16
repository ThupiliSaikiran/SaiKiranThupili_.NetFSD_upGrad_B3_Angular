using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models
{
    public class Products
    {
        public int ProductId { get; set; } // Primary Key & Auto-Increment
        public string ProductName { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }
        public string Category { get; set; }
    }
}
