using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ContactController : Controller
    {
        public static List<ContactInfo> contacts = new List<ContactInfo>
            {
                new ContactInfo { ContactId = 1, FirstName = "Sai", LastName = "Kiran", CompanyName = "TCS", EmailId = "sai@gmail.com", MobileNo = 9876543210, Designation = "Developer" },
                new ContactInfo { ContactId = 2, FirstName = "Rahul", LastName = "Sharma", CompanyName = "Infosys", EmailId = "rahul@gmail.com", MobileNo = 9123456780, Designation = "Tester" },
                new ContactInfo { ContactId = 3, FirstName = "Anjali", LastName = "Reddy", CompanyName = "Wipro", EmailId = "anjali@gmail.com", MobileNo = 9988776655, Designation = "HR" },
                new ContactInfo { ContactId = 4, FirstName = "Vikram", LastName = "Singh", CompanyName = "HCL", EmailId = "vikram@gmail.com", MobileNo = 9012345678, Designation = "Manager" }
            };

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ShowContacts()
        {

            return View(contacts);
        }

        public IActionResult GetContactById(int Id)
        {
            var contact = contacts.FirstOrDefault(c => c.ContactId == Id);

            return View(contact);
        }

        [HttpGet]
        public IActionResult AddContact()
        {
            

            return View();
        }

        [HttpPost]
        public IActionResult AddContact(ContactInfo contactInfo)
        {

            if (ModelState.IsValid)
            {
                contacts.Add(contactInfo);


                return RedirectToAction("ShowContacts");
            }

            return View(contactInfo);
            
        }



    }
}
