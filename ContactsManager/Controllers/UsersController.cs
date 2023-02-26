using ContactsManager.Models;
using ContactsManager.Repositories.UserRepository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ContactsManager.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserRepo _userRepo;

        public UsersController(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        public ActionResult<IEnumerable<UserModel>> Index()
        {
            var model =  _userRepo.GetAllUsers();
            return View(model);
        }
        public async Task<ActionResult<UserModel>> AddUser(UserModel user)
        {

            if (ModelState.IsValid)
            {
                user.CreatedDate = DateTime.Now;
                if (user == null)
                {
                     new Exception("Erro!!");
                }
                await _userRepo.InsertUser(user);
                
            }
            else
            {
                ModelState.AddModelError("","não foi possivel");
            }           

            return View(user);
        }
    }
}
