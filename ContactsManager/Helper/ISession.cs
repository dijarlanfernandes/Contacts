using ContactsManager.Models;

namespace ContactsManager.Helper
{
    public interface ISession
    {
        UserModel GetSessionUser();
        void RemoveSessionUser();
        void CreateSessionUser(UserModel user);
       

    }
}
