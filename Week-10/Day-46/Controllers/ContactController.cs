using Contact_Management_Service.Models;
using Contact_Management_Service.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Contact_Management_Service.Exceptions;

namespace Contact_Management_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactRepository _repo;
        private readonly ILogger<ContactController> _logger;
        public ContactController(IContactRepository repo, ILogger<ContactController> logger)
        {
            _repo = repo;
            _logger = logger;
        }


        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetContacts()
        {
            _logger.LogInformation("Fetching all contacts");
            var contacts = await _repo.GetAll();
            return Ok(contacts);

        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            _logger.LogInformation("Fetching contact with Id: {Id}", id);
            var contact = await _repo.GetContactById(id);

            if(contact == null){
                throw new NotFoundException("Contact Not found");
            }

            return Ok(contact);

        }

        [Authorize(Roles = "Admin")]

        [HttpPost]

        public async Task<IActionResult> CreateContact(Contact contact)
        {
            if (!ModelState.IsValid)
            {
                throw new BadRequestException("Invalid input data");
            }
            _logger.LogInformation("Creating new contact");
            var created = await _repo.Createcontact(contact);
            _logger.LogInformation("Contact created with Id: {Id}", created.ContactId);

            return CreatedAtAction("GetById", new { id = created.ContactId }, created);

        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateContact(int id, Contact contact)
        {
            if (!ModelState.IsValid)
                throw new BadRequestException("Invalid input data");

            _logger.LogInformation("Updating contact with Id: {Id}", id);

            var res = await _repo.UpdateContact(id, contact);
            if (res == null)
                throw new NotFoundException("Contact Not found");
            
            return Ok(res);
        }


        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteContact(int id)
        {

            _logger.LogWarning("Deleting contact with Id: {Id}", id);
            var flag = await _repo.DeleteContact(id);
            if (!flag)
                throw new NotFoundException("Contact Not found");
            return NoContent();
        }


    }
}
