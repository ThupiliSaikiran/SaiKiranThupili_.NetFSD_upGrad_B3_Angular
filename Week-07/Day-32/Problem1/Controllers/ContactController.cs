using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _service;

        public ContactController(IContactService service)
        {
            _service = service; 
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ShowContacts()
        {
            return View(_service.GetAllContacts());
        }

        public IActionResult GetContactById(int id)
        {
            var contact = _service.GetContactById(id);
            return View(contact);
        }

        public IActionResult AddContact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddContact(Contact contact)
        {
            if (ModelState.IsValid)
            {
                _service.AddContact(contact);
                return RedirectToAction("ShowContacts");
            }
            return View(contact);
        }
    }
}
