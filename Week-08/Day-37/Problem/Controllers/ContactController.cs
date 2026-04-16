using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplicationAPI1.DataAccess;
using WebApplicationAPI1.Models;
using static System.Net.Mime.MediaTypeNames;

namespace WebApplicationAPI1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactRepository _repo;
        public ContactController(IContactRepository repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public IActionResult GetContacts()
        {
            return Ok(_repo.GetAll());
        }

        [HttpPost]
        public IActionResult Create(ContactInfo contact)
        {
            if (ModelState.IsValid)
            {
                _repo.CreateContact(contact);
                return Ok(new { contact, status = "Contact info added succesfully" });
            }
            else
            {
                return NotFound("Something went wrong!!");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var contact = _repo.GetContactById(id);

            if(contact == null)
            {
                return NotFound("contact Not Found");
            }
            else
            {
                return Ok(contact);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, ContactInfo contact)
        {

            var cont = _repo.UpdateContact(id, contact);
            if (cont != null)
            {
                
                return Ok(new { UpdatedContact = cont, status = "Contact updated succesfully!!" });
            }
            else
            {
                return NotFound("Contact doesnot found");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var contact = _repo.DeleteContact(id);

            if(contact != null)
            {
                return Ok(new { DeletedContact = contact, status = "Contact deleted succesfully!!" });
            }
            else
            {
                return NotFound();
            }
        }
    }
}
