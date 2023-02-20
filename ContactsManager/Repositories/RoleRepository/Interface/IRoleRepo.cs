using ContactsManager.Models;

namespace ContactsManager.Repositories.RoleRepository.Interface
{
    public interface IRoleRepo
    {
        Task<IEnumerable<RoleModel>> GetAllRoles();
        Task<RoleModel> GetRolesById(string id);
        Task<RoleModel> UpdateRole(RoleModel role, string id);
        Task<RoleModel> InsertRole(RoleModel role);
        Task DeleteRole(string id);
    }
}
