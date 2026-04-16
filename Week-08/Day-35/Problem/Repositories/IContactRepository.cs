using System.Security.Cryptography.Pkcs;
using WebApplication2.Models;

namespace WebApplication2.Repositories
{
    public interface IContactRepository
    {
        List<ContactInfo> GetAllContacts();
        ContactInfo GetContactById(int id);
        void AddContact(ContactInfo contact);
        void UpdateContact(ContactInfo contact);
        void DeleteContact(int id);

        List<Company> GetCompanies();
        List<Department> GetDepartments();

    }
}
