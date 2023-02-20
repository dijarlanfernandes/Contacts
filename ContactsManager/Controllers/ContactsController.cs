using Microsoft.AspNetCore.Mvc;

namespace ContactsManager.Controllers
{
    public class ContactsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
