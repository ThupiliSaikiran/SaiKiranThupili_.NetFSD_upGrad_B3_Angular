using System.Security.Cryptography.Pkcs;
using WebApplication1.Models;
namespace WebApplication1.Services
{
    public interface IContactService
    {
        List<Contact> GetAllContacts();
        Contact GetContactById(int id);
        void AddContact(Contact contact);
    }
}
