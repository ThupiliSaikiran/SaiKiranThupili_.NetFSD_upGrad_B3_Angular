using WebApplication2.Models;
using WebApplication2.Repositories;

namespace WebApplication2.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _repo;

        public ContactService(IContactRepository repo)
        {
            _repo = repo;
        }

        public List<ContactInfo> GetContacts()
        {
            return _repo.GetAllContacts();
        }

        public ContactInfo GetById(int id)
        {
            return _repo.GetContactById(id);
        }


        public List<Company> GetAllCompanies()
        {
            return _repo.GetCompanies();    
        }

        public List<Department> GetAllDepartments()
        {
            return _repo.GetDepartments();
        }

        public void Add(ContactInfo contact)
        {
            _repo.AddContact(contact);
        }

        public void Update(ContactInfo contact)
        {
            _repo.UpdateContact(contact);
        }

        public void Delete(int id)
        {
            _repo.DeleteContact(id);
        }

    }
}
