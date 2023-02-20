using ContactsManager.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace ContactsManager.Helper
{
    public class Session : ISession
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public Session(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public  void CreateSessionUser(UserModel user)
        {
            var UserSession = JsonConvert.SerializeObject(user);
             _contextAccessor.HttpContext.Session.SetString("UserLogged", UserSession);
        }

        public UserModel GetSessionUser()
        {
            string UserSession = _contextAccessor.HttpContext.Session.GetString("UserLogged");
            if (!string.IsNullOrEmpty(UserSession)) return null;
            return JsonConvert.DeserializeObject<UserModel>(UserSession);
        }

        public void RemoveSessionUser()
        {
            _contextAccessor.HttpContext.Session.Remove("UserLogged");
            _contextAccessor.HttpContext.Session.Clear();
        }
    }
}
