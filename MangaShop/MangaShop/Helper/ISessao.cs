using MangaShop.Models;

namespace MangaShop.Helper
{
    public interface ISessao
    {
        void CreateUserSession(UserModel user);
        void RemoveUserSession();
        UserModel GetUserSession();
    }
}
