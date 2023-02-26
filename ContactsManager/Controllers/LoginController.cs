using ContactsManager.Models;
using ContactsManager.Repositories.UserRepository.Interface;
using ContactsManager.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace ContactsManager.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserRepo _userRepo;

        public LoginController(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        public IActionResult Index() 
        { 
            return View();
        }        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<LoginViewModel>> Index(LoginViewModel login)
        {

            if (!ModelState.IsValid)
                return View(login);                               
                var emailvalidate = await _userRepo.GetUserByEmail(login.Email);
                if (emailvalidate != null)
                {
                    if (emailvalidate.validatePassword(login.Password))
                    {
                        return RedirectToAction("index","contacts");
                    }
                    else
                    {
                        ModelState.AddModelError("Senha","Usuario ou senha incorreta!");
                    }
                }      
            ModelState.AddModelError("","não foi possivel localizar o usuario!");
            return View(login);
        }
    }
}
