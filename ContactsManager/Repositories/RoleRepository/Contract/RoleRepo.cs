using ContactsManager.Data;
using ContactsManager.Models;
using ContactsManager.Repositories.RoleRepository.Interface;
using Microsoft.EntityFrameworkCore;

namespace ContactsManager.Repositories.RoleRepository.Contract
{
    public class RoleRepo : IRoleRepo
    {
        private readonly ContactContext _contactContext;

        public RoleRepo(ContactContext contactContext)
        {
            _contactContext = contactContext;
        }

        public async Task DeleteRole(string id)
        {
            var roleid = await _contactContext.roles.FirstOrDefaultAsync(x=> x.RoleId == id);
            if (roleid.RoleId == null)
            {
                new Exception("id not found");
            }
            _contactContext.roles.Remove(roleid);
            await _contactContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<RoleModel>> GetAllRoles()
        {
            return await _contactContext.roles.ToListAsync();
        }

        public async Task<RoleModel> GetRolesById(string id)
        {
            if (id == null) new Exception("id not found");
            return await _contactContext.roles.FirstOrDefaultAsync(x=> x.UserId == id);           

        }

        public async Task<RoleModel> InsertRole(RoleModel role)
        {
            if (role != null)
            {
                new Exception("user already exists");
            }
            var roleModel = await _contactContext.roles.AddAsync(role);
            await _contactContext.SaveChangesAsync();

            return roleModel.Entity; 
        }

        public async Task<RoleModel> UpdateRole(RoleModel role, string id)
        {
            
            if (GetRolesById(id)== null)
            {
                new Exception("not found Id");
            }
             _contactContext.roles.Update(role);
            await _contactContext.SaveChangesAsync();
            return role;
        }
    }
}
