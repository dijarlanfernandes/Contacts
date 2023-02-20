using ContactsManager.Data;
using ContactsManager.Models;
using ContactsManager.Repositories.UserRepository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.Xml;

namespace ContactsManager.Repositories.UserRepository.Contract
{
    public class RoleRepo : IRoleRepo
    {
        private readonly ContactContext _contactContext;

        public RoleRepo(ContactContext contactContext)
        {
            _contactContext = contactContext;
        }

        public async Task DeleteUser(string id)
        {
            var userid = await _contactContext.Users.FirstOrDefaultAsync(x=> x.Id == id);
            if (userid.Id == null)
            {
                new Exception("id not found");
            }
            _contactContext.Users.Remove(userid);
            await _contactContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<UserModel>> GetAllUsers()
        {
            return await _contactContext.Users.ToListAsync();
        }

        public async Task<UserModel> GetUsersById(string id)
        {
            if (id == null) new Exception("id not found");
            return await _contactContext.Users.FirstOrDefaultAsync(x=> x.Id == id);           

        }

        public async Task<UserModel> InsertUser(UserModel User)
        {
            if (User != null)
            {
                new Exception("user already exists");
            }
            var usermodel = await _contactContext.Users.AddAsync(User);
            await _contactContext.SaveChangesAsync();

            return usermodel.Entity; 
        }

        public async Task<UserModel> UpdateUser(UserModel User, string id)
        {
            
            if (GetUsersById(id)== null)
            {
                new Exception("not found Id");
            }
             _contactContext.Users.Update(User);
            await _contactContext.SaveChangesAsync();
            return User;
        }
    }
}
