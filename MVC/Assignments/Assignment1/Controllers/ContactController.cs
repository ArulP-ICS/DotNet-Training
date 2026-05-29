using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Assignment1.Models;
using Assignment1.Repositories;
using System.Threading.Tasks;

namespace Assignment1.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactRepository _repository;

        public ContactController()
        {
            _repository = new ContactRepository();
        }

        // GET: Contact
        public async Task<ActionResult> Index()
        {
            var contacts = await _repository.GetAllAsync();
            return View(contacts);
        }

        // GET: Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Create
        [HttpPost]
        public async Task<ActionResult> Create(Contact contact)
        {
            if (ModelState.IsValid)
            {
                await _repository.CreateAsync(contact);
                return RedirectToAction("Index");
            }
            return View(contact);
        }

        // DELETE
        public async Task<ActionResult> Delete(long id)
        {
            await _repository.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}