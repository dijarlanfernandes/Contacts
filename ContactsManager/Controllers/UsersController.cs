using ContactsManager.Models;
using ContactsManager.Repositories.UserRepository.Interface;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ContactsManager.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserRepo _userRepo;

        public UsersController(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        public async Task<ActionResult<IEnumerable<UserModel>>> Index()
        {
            var model = await _userRepo.GetAllUsers();
            return View(model);
        }
        public IActionResult AddUser()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<UserModel>> AddUser(UserModel user, string email, string name)
        {

            if (ModelState.IsValid)
            {
                user.CreatedDate = DateTime.Now;
                if (user == null)
                {
                     new Exception("Erro!!");
                }
                else
                {
                   var namevalidate = await _userRepo.GetUserByName(name);
                   var emailvalidate= await _userRepo.GetUserByEmail(email);
                    if (namevalidate == null)
                    {
                        if (emailvalidate == null)
                            {
                                await _userRepo.InsertUser(user);
                            }                    
                        ModelState.AddModelError("Email","Email de usuario já existe!");
                    }
                   ModelState.AddModelError("Email","Nome de usuario já existe!");
                }                
            }
            else
            {
                ModelState.AddModelError("","não foi possivel ");
            }           

            return View(user);
        }
    }
}
