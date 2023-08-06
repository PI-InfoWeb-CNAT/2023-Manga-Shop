using MangaShop.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Net.Http;

namespace MangaShop.Helper
{
    public class Sessao : ISessao
    {
        private readonly IHttpContextAccessor _httpContext;
        public Sessao(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }
        public void CreateUserSession(UserModel user)
        {
            string userValues = JsonConvert.SerializeObject(user);
            _httpContext.HttpContext.Session.SetString("LoggedUserSession", userValues);
        }

        public UserModel GetUserSession()
        {
            string userSession = _httpContext.HttpContext.Session.GetString("LoggedUserSession");
            if (string.IsNullOrEmpty(userSession)) return null;
            return JsonConvert.DeserializeObject<UserModel>(userSession);
        }

        public void RemoveUserSession()
        {
            _httpContext.HttpContext.Session.Remove("LoggedUserSession");
        }
    }
}
