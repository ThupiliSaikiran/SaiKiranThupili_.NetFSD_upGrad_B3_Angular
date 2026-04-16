using Contact_Management_Service.Models;

namespace Contact_Management_Service.Repository
{
    public interface IContactRepository
    {
        Task<List<Contact>>  GetAll(); 

        Task<Contact> GetContactById(int id);

        Task<Contact> Createcontact(Contact contact);

        Task<Contact> UpdateContact(int id, Contact contact);

        Task<bool> DeleteContact(int id);
    }
}
