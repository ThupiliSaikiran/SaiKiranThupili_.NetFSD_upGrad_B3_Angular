using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models
{
    public class ContactInfo
    {
        public int ContactId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string EmailId { get; set; }

        [Required]
        [RegularExpression(@"^[6-9]\d{9}$", ErrorMessage = "Enter valid mobile number")]
        public string MobileNo { get; set; }

        [Required]
        public string Designation {  get; set; }

        [Required(ErrorMessage = "Select Company")]
        public int? CompanyId { get; set; }

        [Required(ErrorMessage = "Select Department")]
        public int? DepartmentId { get; set; }

        [ValidateNever]
        public Company Company { get; set; }
        [ValidateNever]
        public Department Department { get; set; }




    }
}
