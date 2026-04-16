using WebApplicationAPI1.Models;
namespace WebApplicationAPI1.DataAccess
{
    public interface IContactRepository
    {
        List<ContactInfo> GetAll();

        ContactInfo GetContactById(int Id);

        void CreateContact(ContactInfo contact);

        ContactInfo UpdateContact(int id, ContactInfo contact);

        ContactInfo DeleteContact(int id);


    }

}
