using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Contact
    {
        public int ContactId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string CompanyName {  get; set; }

        [EmailAddress]
        public string EmailId { get; set; }


        [Range(6000000000, 9999999999, ErrorMessage = "Enter valid mobile number")]
        public long MobileNo { get; set; }   

        public string Desingation {  get; set; }


    }
}
