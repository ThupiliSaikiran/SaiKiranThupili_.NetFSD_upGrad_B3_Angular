using Microsoft.AspNetCore.Http.HttpResults;
using WebApplicationAPI1.Models;

namespace WebApplicationAPI1.DataAccess
{
    public class ContactRepository : IContactRepository
    {
        private static List<ContactInfo> contacts = new List<ContactInfo>()
        {
            new ContactInfo { ContactId = 1, FirstName = "Sai", LastName = "Kiran", EmailId = "sai@gmail.com", MobileNo = 9876543210, Designation = "Developer", CompanyId = 1, DepartmentId = 1 },
            new ContactInfo { ContactId = 2, FirstName = "Rahul", LastName = "Sharma", EmailId = "rahul@gmail.com", MobileNo = 9876543211, Designation = "Tester", CompanyId = 2, DepartmentId = 2 },
            new ContactInfo { ContactId = 3, FirstName = "Anjali", LastName = "Reddy", EmailId = "anjali@gmail.com", MobileNo = 9876543212, Designation = "Manager", CompanyId = 1, DepartmentId = 3 },
            new ContactInfo { ContactId = 4, FirstName = "Kiran", LastName = "Kumar", EmailId = "kiran@gmail.com", MobileNo = 9876543213, Designation = "HR", CompanyId = 3, DepartmentId = 2 }
        };
        private static List<Company> companies = new List<Company>()
    {
        new Company { CompanyId = 1, CompanyName = "TCS" },
        new Company { CompanyId = 2, CompanyName = "Infosys" },
        new Company { CompanyId = 3, CompanyName = "Wipro" }
    };

        private static List<Department> departments = new List<Department>()
    {
        new Department { DepartmentId = 1, DepartmentName = "IT" },
        new Department { DepartmentId = 2, DepartmentName = "HR" },
        new Department { DepartmentId = 3, DepartmentName = "Finance" }
    };

        public List<ContactInfo> GetAll()
        {
            foreach(var contact in contacts)
            {
                contact.Company = companies.FirstOrDefault(com => com.CompanyId == contact.CompanyId);
                contact.Department = departments.FirstOrDefault(d => d.DepartmentId == contact.DepartmentId);
            }
            return contacts;
        }

        public ContactInfo GetContactById(int Id)
        {
            var contact = contacts.FirstOrDefault(c=>c.ContactId == Id);

            if(contact != null)
            {
                contact.Company = companies.FirstOrDefault(com => com.CompanyId == contact.CompanyId);
                contact.Department = departments.FirstOrDefault(d => d.DepartmentId == contact.DepartmentId);
                
            }
            return contact;


        }

        public void CreateContact(ContactInfo contact)
        {
            contacts.Add(contact);
        }

        public ContactInfo UpdateContact(int id, ContactInfo contact)
        {
            var cont = contacts.FirstOrDefault(c => c.ContactId ==id);

            if(cont != null)
            {
                cont.FirstName = contact.FirstName;
                cont.LastName = contact.LastName;
                cont.EmailId = contact.EmailId;
                cont.MobileNo = contact.MobileNo;
    
                cont.Designation = contact.Designation;
                cont.CompanyId = contact.CompanyId;
                cont.DepartmentId = contact.DepartmentId;

                
            }
            return cont;
        }

        public ContactInfo DeleteContact(int id)
        {
            var contact = contacts.FirstOrDefault(c => c.ContactId == id);

            if(contact != null)
            {
                contacts.Remove(contact);
               
            }
            return contact;
        }
    }
}
