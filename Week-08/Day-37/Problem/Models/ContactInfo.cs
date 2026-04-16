using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebApplicationAPI1.Models
{
    public class ContactInfo
    {
        [Key]
        public int ContactId { get; set; }

        [Required]
        public string FirstName { get; set; }

        public string LastName { get; set; }

        [EmailAddress]
        public string EmailId { get; set; }

        public long MobileNo { get; set; }

        public string Designation { get; set; }

        public int CompanyId { get; set; }
        public int DepartmentId { get; set; }


     
        [ForeignKey("CompanyId")]
        public Company? Company { get; set; }


        [ForeignKey("DepartmentId")]
        public Department? Department { get; set; }
    }
}
