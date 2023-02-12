using ContactsManager.Models;

namespace ContactsManager.Repositories.UserRepository.Interface
{
    public interface IUserRepo
    {
        Task<IEnumerable<UserModel>> GetAllUsers();
        Task<UserModel> GetUsersById(string id);
        Task<UserModel> UpdateUser(UserModel User, string id);
        Task<UserModel> InsertUser(UserModel User);
        Task DeleteUser(string id);
    }
}
