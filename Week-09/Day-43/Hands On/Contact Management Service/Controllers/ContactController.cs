using Contact_Management_Service.Models;
using Contact_Management_Service.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Contact_Management_Service.Controllers
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


        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetContacts()
        {
            var contacts = await _repo.GetAll();
            return Ok(contacts);

        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var contact = await _repo.GetContactById(id);

            if(contact == null){
                return NotFound("required Contact not found");
            }

            return Ok(contact);

        }

        [Authorize(Roles ="Admin")]

        [HttpPost]

        public async Task<IActionResult> CreateContact(Contact contact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var res = await _repo.Createcontact(contact);

            return Ok(res);

        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateContact(int id, Contact contact)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var res = await _repo.UpdateContact(id, contact);
            if (res == null)
                return NotFound("Required contact Not found");
            return Ok(res);
        }


        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteContact(int id)
        {
            

            var flag = await _repo.DeleteContact(id);
            if (!flag)
                return NotFound("Required contact Not found");
            return Ok("Contact deleted successfully");
        }


    }
}
