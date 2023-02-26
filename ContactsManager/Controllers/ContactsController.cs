using ContactsManager.Models;
using ContactsManager.Repositories.ContactRepository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ContactsManager.Controllers
{
    public class ContactsController : Controller
    {
        private readonly Helper.ISession _iSession;
        private readonly IContactRepo _contactRepo;

        public ContactsController(Helper.ISession iSession,IContactRepo contactRepo)
        {
            _iSession = iSession;
            _contactRepo = contactRepo;
        }

        public async Task<IActionResult> Index()
        {            
            var list = await _contactRepo.GetAllContactsAsync();
            return View(list);
        }
        public IActionResult NewContact()
        {           
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<ContactModel>> NewContact( ContactModel model)
        {
            if (!ModelState.IsValid)
               return View(model);                
             var contact = await _contactRepo.InsertContact(model);
            return RedirectToAction("index");
        }
    }
}
