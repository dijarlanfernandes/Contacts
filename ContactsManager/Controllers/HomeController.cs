using ContactsManager.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ContactsManager.Controllers
{
    public class HomeController : Controller
    {      

        public IActionResult Index(IFormFile file)
        {         
        
            return View();
        }
        
    }
}