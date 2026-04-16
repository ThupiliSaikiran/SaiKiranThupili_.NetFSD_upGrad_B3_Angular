using WebApplication2.Models;

namespace WebApplication2.Services
{
    public interface IContactService
    {
        List<ContactInfo> GetContacts();

        ContactInfo GetById(int id);

        void Add(ContactInfo contact);

        void Update(ContactInfo contact);

        void Delete(int id);

        List <Company> GetAllCompanies();
        List<Department> GetAllDepartments();
    }
}
