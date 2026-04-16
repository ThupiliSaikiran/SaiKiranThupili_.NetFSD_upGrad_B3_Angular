using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication2.Models;
using WebApplication2.Services;

namespace WebApplication2.Controllers
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
            return View(_service.GetContacts());
        }
        public IActionResult Details(int Id)
        {
            var contact = _service.GetById(Id);
            return View(contact);
        }

        public IActionResult Create()
        {
            var companies = _service.GetAllCompanies();
            var departments = _service.GetAllDepartments();

            ViewBag.Companies = new SelectList(companies, "CompanyId", "CompanyName");
            ViewBag.Departments = new SelectList(departments, "DepartmentId", "DepartmentName");

            
            return View();
        }

        [HttpPost]

        public IActionResult Create(ContactInfo contact)
        {
            if (ModelState.IsValid)
            {
                _service.Add(contact);
                return RedirectToAction("Index");
            }

           
            var companies = _service.GetAllCompanies();
            var departments = _service.GetAllDepartments();

            ViewBag.Companies = new SelectList(companies, "CompanyId", "CompanyName");
            ViewBag.Departments = new SelectList(departments, "DepartmentId", "DepartmentName");

            return View(contact);
        }

        [HttpGet]

        public IActionResult Edit(int id)
        {
            var companies = _service.GetAllCompanies();
            var departments = _service.GetAllDepartments();

            ViewBag.Companies = new SelectList(companies, "CompanyId", "CompanyName");
            ViewBag.Departments = new SelectList(departments, "DepartmentId", "DepartmentName");

            var contactObj = _service.GetById(id);
            return View(contactObj);
        }


        [HttpPost]

        public IActionResult Edit(ContactInfo contact)
        
        {
            if (ModelState.IsValid)
            {
                _service.Update(contact);
                return RedirectToAction("Index");
            }
            
            return View(contact);
        }

        [HttpGet]

        public IActionResult Delete(int id)
        {
            var contactObj = _service.GetById(id);
            return View(contactObj);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirm(int id)
        {
            _service.Delete(id);
            return RedirectToAction("Index");
        }



    }
}
