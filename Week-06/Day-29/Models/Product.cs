using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Product
    {
        // product id --required
        //product name --required, length should be 5 to 15
        //price --    required
        //category ---   length should be 5 to 15

        [Required]
        public int? ProductId { get; set; }

        [Required]
        [StringLength (15, MinimumLength=5)]
        public string ProductName { get; set; }

        [Required]
        public double? Price { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 5)]
        public string Category { get; set; }



    }
}
