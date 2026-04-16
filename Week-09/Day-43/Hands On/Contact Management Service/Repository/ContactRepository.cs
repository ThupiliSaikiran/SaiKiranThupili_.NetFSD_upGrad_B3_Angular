using Contact_Management_Service.Models;
using Microsoft.EntityFrameworkCore;

namespace Contact_Management_Service.Repository
{
    public class ContactRepository : IContactRepository
    {
        private readonly ApplicationDbContext _context;

        public ContactRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Contact>> GetAll()
        {
            return await _context.Contacts.ToListAsync();
        }

        public async Task<Contact> GetContactById(int id)
        {
            var contact = await _context.Contacts.FirstOrDefaultAsync(c => c.ContactId == id);
            if(contact == null)
            {
                return null;
            }

            return contact;
        }

        public async Task<Contact> Createcontact(Contact contact)
        {
            await _context.Contacts.AddAsync(contact);
            await _context.SaveChangesAsync();

            return contact;
        }

        public async Task<Contact> UpdateContact(int id, Contact contact)
        {
            var oldContact = await _context.Contacts.FirstOrDefaultAsync(c => c.ContactId == id);
            if (oldContact == null)
                return null;
            oldContact.Name = contact.Name;
            oldContact.Email = contact.Email;
            oldContact.Phone = contact.Phone;
            oldContact.CategoryId = contact.CategoryId;

            await _context.SaveChangesAsync();

            return oldContact;
        }

        public async Task<bool> DeleteContact(int id)
        {
            var contact = await _context.Contacts.FirstOrDefaultAsync(c => c.ContactId == id);

            if (contact == null)
                return false;

            _context.Contacts.Remove(contact);
            await _context.SaveChangesAsync();

            return true;

        }

    }
}
