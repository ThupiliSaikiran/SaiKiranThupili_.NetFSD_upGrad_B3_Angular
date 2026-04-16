using Microsoft.AspNetCore.Mvc.ModelBinding;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class ContactService : IContactService
    {
        private readonly ApplicationDbContext _context;

        public ContactService(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<Contact> GetAllContacts()
        {

            return _context.Contacts.ToList();
        }

        public Contact GetContactById(int id)
        {
            var contact = _context.Contacts.FirstOrDefault(c => c.ContactId == id);

            return contact;
        }

        public void AddContact(Contact contact)
        {
            _context.Contacts.Add(contact);
            _context.SaveChanges();
        }
    }
}
